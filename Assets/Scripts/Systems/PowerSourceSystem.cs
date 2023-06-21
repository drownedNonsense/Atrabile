using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Data;
using Atrabile.Singletons;


namespace Atrabile.Systems {

[RequireComponent(typeof(PowerSourceArchetype))]
/// <summary> Handles the power source archetype. </summary>
public sealed class PowerSourceSystem : System<PowerSourceArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused)
                foreach (PowerData powerData in this.archetype.data.powerOutputs) {

                    bool output = this.archetype.data.logicGate switch {
                        LogicGate.And  =>   (bool)this.archetype.powerData.activated & powerData.powered,
                        LogicGate.NAnd => !((bool)this.archetype.powerData.activated & powerData.powered),
                        LogicGate.Or   =>   (bool)this.archetype.powerData.activated | powerData.powered,
                        LogicGate.NOr  => !((bool)this.archetype.powerData.activated | powerData.powered),
                        LogicGate.XOr  =>   (bool)this.archetype.powerData.activated ^ powerData.powered,
                        _              =>   (bool)this.archetype.powerData.activated
                    }; // switch ..

                    powerData.powered.SetState(output);

                } // foreach ..
        } // void ..
}} // namespace ..
