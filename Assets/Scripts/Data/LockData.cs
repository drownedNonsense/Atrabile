using UnityEngine;


namespace Atrabile.Data {
public sealed class LockData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        /// <summary> Is true when the entity is locked. </summary>
        public bool locked = true;

        /// <summary> The name of the item that is required to unlock the entity. </summary>
        public string requiredItem = "something";

}} // namespace ..
