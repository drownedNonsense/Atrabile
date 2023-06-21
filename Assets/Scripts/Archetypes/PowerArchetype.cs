using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {
[RequireComponent(typeof(PowerData))]
public class PowerArchetype : Archetype<PowerArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PowerData data { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() =>
            this.data = this.GetComponent<PowerData>();

}} // namespace ..
