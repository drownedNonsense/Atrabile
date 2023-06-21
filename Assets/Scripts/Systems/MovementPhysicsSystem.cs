using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Data;
using Atrabile.Singletons;


namespace Atrabile.Systems {

/// <summary> Handles entity's movement physics. </summary>
[RequireComponent(typeof(PhysicalEntityArchetype))]
public class MovementPhysicsSystem : System<PhysicalEntityArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const float MASS                = 0.1f;
        private const int   MAX_COLLISION_COUNT = 32;

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
            if (!GameVariables.gamePaused)
                this.HandleMovement();
        } // void ..

        private void FixedUpdate() {
            if (!GameVariables.gamePaused)
                this.HandleCollision();
        } // void ..
        
    
    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private void HandleMovement() {

            this.archetype.data.gravitationalDrag
                += this.archetype.data.gravitationalDrag
                *  Time.deltaTime;

            this.archetype.data.velocity = this.archetype.data.absoluteAcceleration
                + Vector3.down
                * this.archetype.data.gravitationalDrag;

            this.transform.position += this.archetype.data.velocity * Time.deltaTime;


            RaycastHit hit;
            if (Physics.Raycast(
                new Ray(this.archetype.collider.bounds.center, Vector3.down),
                out hit,
                this.archetype.collider.bounds.extents.y + 0.3f,
                Generic.OBSTACLE_LAYER_MASK
            )) {

                float heightDifference   = (this.root - hit.point).y;
                this.transform.position += Vector3.down * heightDifference;
                this.archetype.data.SetGrounded(1.5f - 1.4f * hit.normal.y >= heightDifference);

                if (!this.archetype.data.referential)
                    this.archetype.data.referential = hit.collider.GetComponent<MovementData>();

            } else {

                this.archetype.data.SetGrounded(false);
                this.archetype.data.referential = null;

            } // if ..
        } // void ..


        private void HandleCollision() {
            
            Collider[] colliders = new Collider[MovementPhysicsSystem.MAX_COLLISION_COUNT];
            int overlapCount = Physics.OverlapBoxNonAlloc(
                this.archetype.collider.bounds.center,
                this.archetype.collider.bounds.extents * 0.5f,
                colliders,
                this.transform.rotation,
                Generic.OBSTACLE_LAYER_MASK,
                QueryTriggerInteraction.UseGlobal
            ); // OverlapBoxNonAlloc()

            for (int i = 0; i < overlapCount; i++) {

                Vector3 direction;
                float distance;

                if (Physics.ComputePenetration(
                    this.archetype.collider,
                    this.root,
                    this.transform.rotation,
                    colliders[i],
                    colliders[i].transform.position,
                    colliders[i].transform.rotation,
                    out direction,
                    out distance
                )) {
                    
                    Vector3 penetration = direction * distance;
                    this.archetype.data.velocity += penetration * 0.75f;
                    this.transform.position      += penetration * 0.25f;
                    
                } // if ..
	        } // for ..
        } // void ..
}} // namespace ..
