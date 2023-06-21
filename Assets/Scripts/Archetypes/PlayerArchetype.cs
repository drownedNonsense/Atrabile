using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {
    
[RequireComponent(typeof(MovementPhysicsData))]
[RequireComponent(typeof(InteractorData))]
[RequireComponent(typeof(InventoryData))]
[RequireComponent(typeof(CameraData))]
[RequireComponent(typeof(HUDData))]
[RequireComponent(typeof(Controller))]
public class PlayerArchetype : Archetype<PlayerArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementPhysicsData movementData   { get; private set; }
        public InteractorData      interactorData { get; private set; }
        public InventoryData       inventoryData  { get; private set; }
        public CameraData          cameraData     { get; private set; }
        public HUDData             hudData        { get; private set; }
        public Controller          controller     { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.movementData   = this.GetComponent<MovementPhysicsData>();
            this.interactorData = this.GetComponent<InteractorData>();
            this.inventoryData  = this.GetComponent<InventoryData>();
            this.cameraData     = this.GetComponent<CameraData>();
            this.hudData        = this.GetComponent<HUDData>();
            this.controller     = this.GetComponent<Controller>();
        } // void ..
}} // namespace ..
