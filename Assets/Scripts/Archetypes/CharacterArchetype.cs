using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {
    
[RequireComponent(typeof(MovementPhysicsData))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class CharacterArchetype : Archetype<CharacterArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public     MovementPhysicsData movementPhysicsData { get; private set; }
        public     Animator            animator            { get; private set; }
        public new Collider            collider            { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.movementPhysicsData = this.GetComponent<MovementPhysicsData>();
            this.animator            = this.GetComponent<Animator>();
            this.collider            = this.GetComponent<Collider>();
        } // void ..
}} // namespace ..
