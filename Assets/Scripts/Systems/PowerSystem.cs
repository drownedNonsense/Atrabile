using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Singletons;


namespace Atrabile.Systems {

[RequireComponent(typeof(PowerArchetype))]
/// <summary> Handles the power source archetype. </summary>
public sealed class PowerSystem : System<PowerArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void LateUpdate() {
            if (!GameVariables.gamePaused) {

                this.archetype.data.activated.SetState(
                    this.archetype.data.powered
                    | (this.archetype.data.activated && this.archetype.data.remainActivated));

                this.archetype.data.powered.UnSet();
            } // if ..
        } // void ..
}} // namespace ..
