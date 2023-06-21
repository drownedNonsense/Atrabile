using UnityEngine;
using Atrabile.Interfaces;
using Atrabile.Singletons;


namespace Atrabile.ScriptableObjects {
[CreateAssetMenu(fileName = "Data", menuName = "Interactable")]
public class Interactable : ScriptableObject {

    [field: SerializeField] public string              ActionName  { get; private set; }
    [field: SerializeField] public Generic.Interaction ActionType  { get; private set; }
    [field: SerializeField] public AudioClip           ActionSound { get; private set; }
    
    public static Interactable Default() => GameVariables.defaultInteractable
        ? GameVariables.defaultInteractable
        : Resources.Load<Interactable>("Interactables/Default");
}} // namespace ..
