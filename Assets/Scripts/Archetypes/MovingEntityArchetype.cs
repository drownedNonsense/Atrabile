using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(MovementData))]
[RequireComponent(typeof(AudioSource))]
public class MovingEntityArchetype : Archetype<MovingEntityArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData data        { get; private set; }
        public AudioSource  audioSource { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data        = this.GetComponent<MovementData>();
            this.audioSource = this.GetComponent<AudioSource>();
        } // void ..
}} // namespace ..
