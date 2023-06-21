using UnityEngine;
using Atrabile.Systems;


namespace Atrabile.Data {
public class PowerData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
    
        /// <summary> Is true when the entity is currently receiving power by a laser or another power source. </summary>
        public State powered = false;

        /// <summary> Is true when the entity is powered. </summary>
        public State activated = false;

        /// <summary> The entity's power won't turn off after the power source is disabled. </summary>
        public bool remainActivated = false;

}} // namespace ..
