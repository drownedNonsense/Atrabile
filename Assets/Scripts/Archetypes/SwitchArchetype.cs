using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class SwitchArchetype : Archetype<SwitchArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PowerData   powerData   { get; private set; }
        public Animator    animator    { get; private set; }
        public AudioSource audioSource { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.powerData   = this.GetComponent<PowerData>();
            this.animator    = this.GetComponent<Animator>();
            this.audioSource = this.GetComponent<AudioSource>();
        } // void ..
}} // namespace ..
