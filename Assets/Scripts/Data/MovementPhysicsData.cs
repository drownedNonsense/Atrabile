using UnityEngine;


namespace Atrabile.Data {
public class MovementPhysicsData : MovementData {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const float GRAVITATIONAL_CONSTANT = 9.8f / 2f;

        /// <summary> The entity's movement vector per seconds. </summary>
        public Vector3 velocity = Vector3.zero;
        
        /// <summary> The entity's acceleration toward a specified direction within its referential. </summary>
        public Vector3 absoluteAcceleration => this.acceleration + this.referential switch {
            null => Vector3.zero,
            _    => this.referential.acceleration,
        }; // switch ..

        /// <summary> The entitiy's drag toward the ground. </summary>
        public float gravitationalDrag = MovementPhysicsData.GRAVITATIONAL_CONSTANT;

        /// <summary> The entity's referential. </summary>
        public MovementData referential = null;

        /// <summary> Is enabled when the entity is standing on the ground. </summary>
        public State grounded { get; private set; } = State.none;

        /// <summary> Sets the entity's grounded state. </summary>
        public void SetGrounded(bool grounded) {
            switch (grounded) {
                case (true)  : {
                    this.gravitationalDrag = 0f; 
                    this.grounded.Set();
                    break;
                } // case ..
                case (false) : {
                    this.gravitationalDrag = this.gravitationalDrag == 0f
                        ? MovementPhysicsData.GRAVITATIONAL_CONSTANT
                        : this.gravitationalDrag;
                        
                    this.grounded.UnSet();
                    break;
                } // case ..
            } // switch ..
        } // void ..
}} // namespace ..
