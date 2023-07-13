using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour {
    Player_interaction _interaction;

    public float _dialogueTime = 2.5f;
    private bool _onTrigger = false;

    [TextArea(2,4)]
    public string _text;

    private void Start() {
        _interaction = Player_interaction._interaction;
    }

    public void EnterDialogue() {
        _interaction.SetDialogueBox("_dialogueOn", _text);
    }
    public void ExitDialogue() {
        _interaction.SetDialogueBox("_dialogueOff", "");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _onTrigger = true;

            _interaction.InteractableFound(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _onTrigger = false;

            _interaction.InteractableFound(false);
        }
    }

    private IEnumerator StartDialogue() {
        EnterDialogue();
        yield return new WaitForSeconds(_dialogueTime);
        ExitDialogue();
    }

    void Input() {
        StopAllCoroutines();
        StartCoroutine(StartDialogue());
    }

    void Update() {
        if (_onTrigger && Player_input._input.InteractionInput()) {
            Input();
        }
    }
}
