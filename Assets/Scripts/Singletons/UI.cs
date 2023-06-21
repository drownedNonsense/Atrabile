using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Atrabile.Archetypes;
using Atrabile.ScriptableObjects;
using Atrabile.Interfaces;


namespace Atrabile.Singletons {
/// <summary> Atrabile's UI. </summary>
public sealed class UI : Singleton<UI>, IDefault<UI> {

    [SerializeField] private TextMeshProUGUI _dialogueBox;
    [SerializeField] private Interactable    _dialogueAction;
    [SerializeField] private Image           _nextDialogueButton;
    [SerializeField] private Image           _fadeBlack;
                     private AudioSource     _audioSource;

    private static TextMeshProUGUI dialogueBox        => UI.instance._dialogueBox;
    private static Interactable    dialogueAction     => UI.instance._dialogueAction;
    private static Image           nextDialogueButton => UI.instance._nextDialogueButton;
    private static AudioSource     audioSource        => UI.instance._audioSource;
    private static Image           fadeBlack          => UI.instance._fadeBlack;
    private static bool isFading;

    protected override void Awake() {
        base.Awake();
        this._audioSource = this.GetComponent<AudioSource>();
    } // void ..

    public static void DisplayDialogue(
        PlayerArchetype activePlayer,
        string[]        lines,
        Color           color
    ) => UI.instance.StartCoroutine(
            UI.CDialogue(
                activePlayer,
                lines,
                color
            )); // CDialogue()


    public static void DisplayDialogue(
        PlayerArchetype activePlayer,
        string          line,
        Color           color
    ) => UI.instance.StartCoroutine(
            UI.CDialogue(
                activePlayer,
                new string[] {line},
                color
            )); // CDialogue()

    public static void FadeOut(float time) => UI.instance.StartCoroutine(UI.CFadeOut(time));
    private static IEnumerator CFadeOut(float time) {

        if (!UI.isFading) {

            UI.isFading = true;    
            
            Color fade = UI.fadeBlack.color;
            fade.a = 0f;
            UI.fadeBlack.gameObject.SetActive(true);
            UI.fadeBlack.color = fade;

            while (UI.fadeBlack.color.a < 1f) {

                fade.a += Time.deltaTime / time;
                UI.fadeBlack.color = fade;
                yield return new WaitForEndOfFrame();

            } // while ..
        } // if ..
    } // IEnumerator ..


    private static IEnumerator CDialogue(
        PlayerArchetype activePlayer,
        string[]        lines,
        Color           color
    ) {

        GameVariables.gamePaused = true;
        UI.dialogueBox.text   = "";     
        UI.dialogueBox.color  = color;
        UI.dialogueBox.transform.parent.gameObject.SetActive(true);
        activePlayer.interactorData.currentAction.SetSome(UI.dialogueAction);

        foreach (string line in lines) {

            char[] characters = new char[line.Length];
            for (int index = 0; index + 1 < line.Length && !activePlayer.controller.a.stateExit; index++) {

                characters[index] = line[index];
                UI.dialogueBox.text = characters.ArrayToString();
                
                yield return line[index] switch {
                    '.' => new WaitForSeconds(0.75f),
                    '!' => new WaitForSeconds(0.75f),
                    '?' => new WaitForSeconds(0.75f),
                    ':' => new WaitForSeconds(0.5f),
                    ';' => new WaitForSeconds(0.5f),
                    ',' => new WaitForSeconds(0.5f),
                    _   => new WaitForSeconds(0.01f),
                }; // switch ..
            } // while ..

            UI.dialogueBox.text           = line;
            UI.nextDialogueButton.gameObject.SetActive(true);
            while (!activePlayer.controller.a.stateExit)
                yield return new WaitForEndOfFrame();

            UI.nextDialogueButton.gameObject.SetActive(false);
            UI.audioSource.PlayOneShot(UI.dialogueAction.ActionSound);

        } // foreach ..


        GameVariables.gamePaused = false;
        UI.dialogueBox.transform.parent.gameObject.SetActive(false);
        activePlayer.interactorData.currentAction.SetNone();
            
    } // IEnumerator ..
}} // namespace ..
