using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Interfaces;
using Atrabile.Singletons;
using Atrabile.ScriptableObjects;


namespace Atrabile.Systems {

[RequireComponent(typeof(LockArchetype))]
/// <summary> Handles locked entities. </summary>
public sealed class LockSystem : System<LockArchetype>, IInteractable {

    /*#########*/
    /* D A T A */
    /*#########*/

        [field: SerializeField] public Interactable action { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void LateUpdate() {
            if (!GameVariables.gamePaused) {
                if (this.archetype.powerData.activated.stateEnter && this.archetype.data.locked)
                    this.archetype.audioSource.PlayOneShot(this.action.ActionSound);

                this.archetype.powerData.activated &= !this.archetype.data.locked;
            } // if ..
        } // void .


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        public void Interact(PlayerArchetype playerArchetype) {
            if (this.archetype.data.locked)
                if (playerArchetype.inventoryData.storyDriveOrigins.Count != 0) {

                    UI.DisplayDialogue(
                        playerArchetype,
                        $"You used {this.archetype.data.requiredItem.ToLower()} you found in {playerArchetype.inventoryData.storyDriveOrigins[0].ToLower()}.",
                        Color.white
                    ); // DisplayDialogue()

                    this.archetype.data.locked.UnSet();
                    playerArchetype.inventoryData.storyDriveOrigins.RemoveAt(0);
                    playerArchetype.interactorData.currentAction.SetNone();

                } else UI.DisplayDialogue(
                    playerArchetype,
                    $"You need {this.archetype.data.requiredItem.ToLower()}!",
                    Color.white
                ); // DisplayDialogue()
        } // void ..
}} // namespace ..
