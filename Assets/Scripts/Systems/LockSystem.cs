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

        private void Update() {
            if (!GameVariables.gamePaused) {

                if (this.archetype.data.locked) {
                    switch ((byte)this.archetype.powerData.activated) {
                        case (State.ENTER) : { this.archetype.audioSource.PlayOneShot(this.action.ActionSound); break; }
                        default            : { this.archetype.powerData.activated.UnSet(); break; }
                    } // switch ..
                } // if ..
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

                    this.archetype.data.locked = false;
                    playerArchetype.inventoryData.storyDriveOrigins.RemoveAt(0);
                    playerArchetype.interactorData.currentAction.SetNone();

                    // Removes lock behaviours.
                    this.archetype.RemoveSystem(this);
                    Destroy(this.archetype.data);

                } else UI.DisplayDialogue(
                    playerArchetype,
                    $"You need {this.archetype.data.requiredItem.ToLower()}!",
                    Color.white
                ); // DisplayDialogue()
        } // void ..
}} // namespace ..
