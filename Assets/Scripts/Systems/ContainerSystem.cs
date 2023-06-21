using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Interfaces;
using Atrabile.Singletons;
using Atrabile.ScriptableObjects;


namespace Atrabile.Systems {

[RequireComponent(typeof(ContainerArchetype))]
/// <summary> Handles containers. </summary>
public sealed class ContainerSystem : System<ContainerArchetype>, IInteractable {

    /*#########*/
    /* D A T A */
    /*#########*/

        [field: SerializeField] public Interactable action { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        public void Interact(PlayerArchetype playerArchetype) {

            if (this.archetype.powerData.activated) {

                int supplies           = this.archetype.data.supply;
                int storyDriveElements = this.archetype.data.storyDriveOrigins.Count;

                playerArchetype.inventoryData.supply += supplies;
                playerArchetype.inventoryData
                    .storyDriveOrigins
                    .AddRange(this.archetype.data.storyDriveOrigins);
                
                this.archetype.data.supply = 0;
                this.archetype.data.storyDriveOrigins.Clear();
                playerArchetype.interactorData.currentAction.SetNone();

                string info = "You found ";
                if (supplies != 0) {
                    if (supplies == 1) info += $"1 supply";
                    else               info += $"{supplies} supplies";
                    if (storyDriveElements != 0) info += " and ";
                    else                         info += "!";
                } else if (storyDriveElements == 0) info += "nothing...";

                if (storyDriveElements != 0)
                    if (storyDriveElements == 1) info += "1 story drive element!";
                    else                         info += $"{storyDriveElements} story drive elements!";

                UI.DisplayDialogue(
                    playerArchetype,
                    info,
                    Color.white
                ); // DisplayDialogue()
            } // if ..
        } // void ..
}} // namespace ..
