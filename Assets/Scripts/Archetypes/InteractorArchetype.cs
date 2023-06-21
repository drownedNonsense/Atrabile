using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(InteractorData))]
[RequireComponent(typeof(Collider))]
public class InteractorArchetype : Archetype<InteractorArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public     InteractorData data     { get; private set; }
        public new Collider       collider { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data      = this.GetComponent<InteractorData>();
            this.collider  = this.GetComponent<Collider>();
        } // void ..
}} // namespace ..
