using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(PathFollowerData))]
[RequireComponent(typeof(MovementData))]
public class PathFollowerArchetype : Archetype<PathFollowerArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PathFollowerData data         { get; private set; }
        public MovementData     movementData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data         = this.GetComponent<PathFollowerData>();
            this.movementData = this.GetComponent<MovementData>();
        } // void ..
}} // namespace ..
