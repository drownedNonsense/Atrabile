using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Interfaces;
using Atrabile.Singletons;
using Atrabile.ScriptableObjects;


namespace Atrabile.Systems {

[RequireComponent(typeof(SwitchArchetype))]
/// <summary> Handles switches. </summary>
public sealed class SwitchSystem : System<SwitchArchetype>, IInteractable {

    /*#########*/
    /* D A T A */
    /*#########*/

        private static int TOGGLED = Animator.StringToHash("Toggled");
        
        [field: SerializeField] public Interactable action { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused) {

                this.archetype.animator.SetBool(SwitchSystem.TOGGLED, this.archetype.powerData.activated);
                
                if (this.archetype.powerData.activated.stateEnter
                || this.archetype.powerData.activated.stateExit)
                    this.archetype.audioSource.PlayOneShot(this.action.ActionSound);

            } // if ..
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        public void Interact(PlayerArchetype playerArchetype) {
            this.archetype.powerData.activated.Toggle();
            playerArchetype.interactorData.currentAction.SetNone();
        } // void ..
}} // namespace ..
