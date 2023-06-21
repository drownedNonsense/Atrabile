using UnityEngine;


namespace Atrabile.Data {
public class MovementData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        /// <summary> The entity's acceleration toward a specified direction. </summary>
        public Vector3 acceleration = Vector3.zero;
        
        /// <summary> The entity's orientation. </summary>
        public Vector2 orientation = Vector2.zero;

        /// <summary> The entity's speed. </summary>
        public float speed = 1f;

}} // namespace ..
