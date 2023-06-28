using UnityEngine;


namespace Atrabile {
/// <summary> Performs actions to a specified archetype. </summary>
public class System<ARCHETYPE> : MonoBehaviour where ARCHETYPE : Archetype<ARCHETYPE> {

    protected ARCHETYPE archetype;
    protected virtual void Awake() {
        this.archetype = this.GetComponent<ARCHETYPE>();
        this.archetype.systems.Add(this);
    } // void ..
}} // namespace ..
