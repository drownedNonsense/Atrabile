using Atrabile.Archetypes;
using Atrabile.ScriptableObjects;


namespace Atrabile.Interfaces {
public interface IInteractable {

    /// <summary> Performs an action when the entity is interacted with. </summary>
    void Interact(PlayerArchetype playerArchetype) {}
    void Interact()                                {}

    Interactable action => null;

}} // namespace ..
