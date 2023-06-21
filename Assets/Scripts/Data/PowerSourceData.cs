using UnityEngine;


namespace Atrabile.Data {
public class PowerSourceData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
    
        /// <summary> An array of entities data that can be powered by the entity. </summary>
        public PowerData[] powerOutputs = null;

        /// <summary> Defines how does the power output work. </summary>
        public LogicGate logicGate = LogicGate.Or;

}} // namespace ..
