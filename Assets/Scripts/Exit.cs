using UnityEngine;
using Atrabile.Interfaces;
using Atrabile.Singletons;


namespace Atrabile {
public class Exit : MonoBehaviour, IInteractable {

    public void Interact() {

        UI.FadeOut(2f);

    } // void ..
}} // namespace ..
