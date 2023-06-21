using UnityEngine;
using Atrabile.ScriptableObjects;
using Atrabile.Interfaces;


namespace Atrabile.Singletons {
/// <summary> Features Atrabile's global variables. </summary>
public sealed class GameVariables : Singleton<GameVariables> {

    private AudioClip _switchSound;
    private AudioClip _metalSound;
    private AudioClip _gearsSound;
    private Interactable _defaultInteractable;

    public static AudioClip switchSound            => GameVariables.instance._switchSound;
    public static AudioClip metalSound             => GameVariables.instance._metalSound;
    public static AudioClip gearsSound             => GameVariables.instance._gearsSound;
    public static Interactable defaultInteractable => GameVariables.instance._defaultInteractable;
    public static bool gamePaused = false;

    protected override void Awake() {
        base.Awake();
        this._switchSound = Resources.Load<AudioClip>("Sounds/switch");
        this._metalSound  = Resources.Load<AudioClip>("Sounds/metal");
        this._gearsSound  = Resources.Load<AudioClip>("Sounds/gears");
        this._defaultInteractable = Resources.Load<Interactable>("Interactables/Default");
    } // void ..
}} // namespace ..
