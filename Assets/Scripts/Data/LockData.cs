using UnityEngine;


namespace Atrabile.Data {
public sealed class LockData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        /// <summary> The entity's lock state. </summary>
        public State locked = State.some;

        /// <summary> The name of the item that is required to unlock the entity. </summary>
        public string requiredItem = "something";

}} // namespace ..
