using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.ScriptableObjects;


namespace Atrabile.Systems {

[RequireComponent(typeof(PlayerArchetype))]
/// <summary> Handles player's HUD. </summary>
public sealed class HUDSystem : System<PlayerArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {

            for (int index = 0; index < this.archetype.hudData.supplyBars.Length; index++)
                this.archetype.hudData.supplyBars[index].color = index < this.archetype.inventoryData.supply
                    ? new Color32(255, 064, 064, 255)
                    : new Color32(255, 255, 255, 016);

            for (int index = 0; index < this.archetype.hudData.storyDriveBars.Length; index++)
                this.archetype.hudData.storyDriveBars[index].color = index < this.archetype.inventoryData.storyDriveOrigins.Count
                    ? new Color32(128, 160, 255, 255)
                    : new Color32(255, 255, 255, 016);

            this.archetype.hudData.aAction.text = ((Interactable)this.archetype.interactorData.currentAction).ActionName;

        } // void ..
}} // namespace ..
