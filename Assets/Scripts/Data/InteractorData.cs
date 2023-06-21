using System.Collections.Generic;
using UnityEngine;
using Atrabile.Interfaces;
using Atrabile.ScriptableObjects;


namespace Atrabile.Data {
public sealed class InteractorData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        /// <summary> A list of interactables around the entity. </summary>
        public HashSet<IInteractable> interactables = new HashSet<IInteractable>();

        public Option<Interactable> currentAction = Option<Interactable>.Some(Interactable.Default);

}} // namespace ..
