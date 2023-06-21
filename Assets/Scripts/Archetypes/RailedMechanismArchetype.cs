using UnityEngine;
using Atrabile.Data;


namespace Atrabile.Archetypes {

[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(PathFollowerData))]
public class RailedMechanismArchetype : Archetype<RailedMechanismArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PowerData        powerData { get; private set; }
        public PathFollowerData pathData  { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.powerData = this.GetComponent<PowerData>();
            this.pathData  = this.GetComponent<PathFollowerData>();
        } // void ..
}} // namespace ..
