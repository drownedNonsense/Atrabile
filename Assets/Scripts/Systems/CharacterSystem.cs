using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Singletons;


namespace Atrabile.Systems {

[RequireComponent(typeof(CharacterArchetype))]
/// <summary> Handles characters. </summary>
public sealed class CharacterSystem : System<CharacterArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private static int WALK_SPEED  = Animator.StringToHash("WalkSpeed");
        private static int IS_IDLE     = Animator.StringToHash("IsIdle");


        private Vector3 root => this.archetype
            .collider
            .bounds
            .center - this.archetype
                .collider
                .bounds
                .extents
                .YConstraint();


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused) {

                float walkSpeed = this.archetype
                    .movementPhysicsData
                    .acceleration
                    .XZConstraint()
                    .magnitude;

                this.transform.rotation = Quaternion.Lerp(
                    this.transform.rotation,
                    Quaternion.LookRotation(
                        this.archetype
                            .movementPhysicsData
                            .acceleration
                            .XZConstraint()
                            .AnyOr(this.transform.forward),
                        Vector3.up),
                    0.25f
                ); // Lerp()

                this.archetype.animator.SetFloat(
                    CharacterSystem.WALK_SPEED,
                    this.archetype
                        .movementPhysicsData
                        .velocity
                        .XZConstraint()
                        .magnitude
                ); // SetFloat()

                this.archetype.animator.SetBool(CharacterSystem.IS_IDLE, walkSpeed < 2f);
                this.archetype.animator.SetFloat(
                    CharacterSystem.WALK_SPEED,
                    (byte)this.archetype.movementPhysicsData.grounded switch {
                        State.ENABLED => walkSpeed,
                        _             => 0f,
                }); // SetFloat()

                switch ((byte)this.archetype.movementPhysicsData.grounded) {
                    case (State.ENTER) : { this.HandleLand(); break; }
                    case (State.EXIT)  : { this.HandleJump(); break; }
                } // switch ..                
            } // if ..
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private void HandleLand() {
            this.archetype.movementPhysicsData.velocity.y     = 0f;
            this.archetype.movementPhysicsData.acceleration.y = 0f;
        } // void ..


        private void HandleJump() {

            if (!Physics.Raycast(
                this.root,
                (this.archetype.movementPhysicsData.velocity.normalized + Vector3.down),
                this.archetype.collider.bounds.extents.y,
                Generic.OBSTACLE_LAYER_MASK
            )) {

                Vector3 relativeAcceleration = this.transform.InverseTransformVector(
                    this.archetype
                        .movementPhysicsData
                        .acceleration
                ); // InverseTransformVector()
                
                this.archetype.movementPhysicsData.acceleration = Quaternion.LookRotation(
                    new Vector3(
                        this.archetype.movementPhysicsData.acceleration.x,
                        0f,
                        this.archetype.movementPhysicsData.acceleration.z
                    ), Vector3.up
                ) * new Vector3(
                    relativeAcceleration.x,
                    Mathf.Abs(relativeAcceleration.z),
                    relativeAcceleration.z
                ); // Vector3()
            } // if ..
        } // void ..
}} // namespace ..
