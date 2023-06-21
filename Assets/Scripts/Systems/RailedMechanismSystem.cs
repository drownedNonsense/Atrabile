using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Singletons;


namespace Atrabile.Systems {

[RequireComponent(typeof(RailedMechanismArchetype))]
/// <summary> Handles entities that require power to move along a path. </summary>
public sealed class RailedMechanismSystem : System<RailedMechanismArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused)
                this.archetype.pathData.movementDirection = (byte)this.archetype
                    .powerData
                    .activated switch {
                        State.ENTER => Sign.pos,
                        State.EXIT  => this.archetype.pathData.mode == Data.PathFollowerData.Mode.MoveOnce ? Sign.neg : Sign.zero,
                        _           => this.archetype.pathData.movementDirection,
                }; // switch ..
        } // void ..
}} // namespace ..
