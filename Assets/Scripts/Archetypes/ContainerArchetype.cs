using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {
    
[RequireComponent(typeof(InventoryData))]
[RequireComponent(typeof(PowerData))]
public class ContainerArchetype : Archetype<ContainerArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public InventoryData data      { get; private set; }
        public PowerData     powerData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data      = this.GetComponent<InventoryData>();
            this.powerData = this.GetComponent<PowerData>();
        } // void ..
}} // namespace ..
