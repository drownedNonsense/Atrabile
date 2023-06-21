using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Interfaces;
using Atrabile.Singletons;


namespace Atrabile.Systems {

[RequireComponent(typeof(PlayerArchetype))]
/// <summary> Handles the entity's movement from player input. </summary>
public sealed class PlayerInputSystem : System<PlayerArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const float CAMERA_ROTATION_SPEED = 180f;
        private Vector3 head => this.transform.position + Vector3.up * 2f;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void LateUpdate() {
            if (!GameVariables.gamePaused) {

                RaycastHit hit;
                if (Physics.Raycast(
                    this.head,
                    this.archetype.cameraData.camera.transform.position - this.head,
                    out hit,
                    this.archetype.cameraData.distance.magnitude,
                    Generic.OBSTACLE_LAYER_MASK
                )) this.archetype.cameraData.camera.transform.position = hit.point;


                this.archetype.movementData.orientation.y += this.archetype.controller.z
                    * PlayerInputSystem.CAMERA_ROTATION_SPEED
                    * Time.deltaTime;

                this.archetype.movementData.orientation.y = this.archetype.movementData.orientation.y % 360f;


                this.archetype.cameraData.camera.transform.LookAt(this.head);
                this.archetype.cameraData.cameraTarget.position = this.transform.position
                    + this.archetype.cameraData.distance.y * Vector3.up
                    + Quaternion.AngleAxis(this.archetype.movementData.orientation.y, Vector3.up)
                    * -this.transform.forward
                    * (this.archetype.cameraData.distance.x + Mathf.Abs(this.archetype.movementData.orientation.y / 60f));

                this.archetype.movementData.acceleration = this.archetype.movementData.grounded
                    ? Quaternion.AngleAxis(this.archetype.cameraData.camera.transform.eulerAngles.y, Vector3.up)
                        * this.archetype.controller.movement.ToFlat3D()
                        * this.archetype.movementData.speed
                    : this.archetype.movementData.acceleration;

                this.archetype.movementData.orientation.y /= Mathf.Clamp(
                    Mathf.Abs(this.transform.InverseTransformVector(this.archetype.movementData.acceleration).z),
                    1f + Time.deltaTime * 0.80f,
                    1f + Time.deltaTime * 0.01f * PlayerInputSystem.CAMERA_ROTATION_SPEED
                ); // Max()

                if (this.archetype.controller.a.stateExit)
                    foreach (IInteractable interactable in this.archetype.interactorData.interactables)
                        interactable.Interact(this.archetype);
            } // if ..
        } // void ..
}} // namespace ..
