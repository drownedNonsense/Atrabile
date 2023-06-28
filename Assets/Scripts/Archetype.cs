using System.Collections.Generic;
using UnityEngine;


namespace Atrabile {
[ExecuteInEditMode]
/// <summary> An abstract class that works as a query of components, classes and structs for systems. </summary>
public abstract class Archetype<ARCHETYPE> : MonoBehaviour where ARCHETYPE : Archetype<ARCHETYPE> {

    /// <summary> The archetype's registered systems. </summary>
    public HashSet<System<ARCHETYPE>> systems = new HashSet<System<ARCHETYPE>>();

    /// <summary> Removes a system from the dependency while checking if the archetype should be kept or destroyed. </summary>
    public void RemoveSystem(System<ARCHETYPE> system) {
        this.systems.Remove(system);
        Destroy(system);
        if (this.systems.Count == 0) Destroy(this);
    } // void ..

    /// <summary> An abstract function to initialise components and add systems. </summary>
    protected abstract void InitComponents();
    protected virtual void Awake() => this.InitComponents();
    
}} // namespace ..
