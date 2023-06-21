using UnityEngine;
using Atrabile.Interfaces;


namespace Atrabile {
/// <summary> Implements a static instance while enforcing its runtime safety. </summary>
public class Singleton<COMPONENT> : MonoBehaviour where COMPONENT : Component {

    /*#########*/
    /* D A T A */
    /*#########*/
        
        /// <summary> A reference to the current instance of the singleton. </summary>
        public    static COMPONENT          instance => Singleton<COMPONENT>._instance;
        protected static Option<COMPONENT> _instance =  Option<COMPONENT>.Some(Default);


        /// <summary> A constructor for singleton instances. </summary>
        public static COMPONENT Default() {

            COMPONENT instance = GameObject.FindObjectOfType<COMPONENT>();
            if (!instance) {

                GameObject statics     = new GameObject("Statics");
                           statics.tag = "Statics";
                instance = statics.AddComponent<COMPONENT>();

            } // if ..


            return instance;

        } // COMPONENT ..

 
    /*###################*/
    /* L I F E   T I M E */
    /*###################*/
        
        protected virtual void Awake () {
            if (Singleton<COMPONENT>._instance.isNull) {

                Singleton<COMPONENT>._instance = this as COMPONENT;
                DontDestroyOnLoad(this.gameObject);

            } else Destroy(gameObject);
        } // void ..
}} // namespace ..
