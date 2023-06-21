using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(LockData))]
[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(AudioSource))]
public class LockArchetype : Archetype<LockArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public LockData    data        { get; private set; }
        public PowerData   powerData   { get; private set; }
        public AudioSource audioSource { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data        = this.GetComponent<LockData>();
            this.powerData   = this.GetComponent<PowerData>();
            this.audioSource = this.GetComponent<AudioSource>();
        } // void ..
}} // namespace ..
