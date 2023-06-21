using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(MovementPhysicsData))]
public class PhysicalEntityArchetype : Archetype<PhysicalEntityArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public     MovementPhysicsData data      { get; private set; }
        public new Collider            collider  { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data     = this.GetComponent<MovementPhysicsData>();
            this.collider = this.GetComponent<Collider>();
        } // void ..
}} // namespace ..
