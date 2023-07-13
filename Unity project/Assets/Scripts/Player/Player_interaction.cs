using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_interaction : MonoBehaviour {
    public static Player_interaction _interaction;

    public GameObject _interactionIndicator;

    [Header("Dialogues")]
    public TextMeshProUGUI _dialogueText;
    public Animator _dialogueBoxAnimator;

    private void Awake() {
        _interaction = this;
    }

    public void InteractableFound(bool found) {
        _interactionIndicator.SetActive(found);
    }

    public void SetDialogueBox(string _triggerName, string _text) {
        _dialogueBoxAnimator.SetTrigger(_triggerName);
        _dialogueText.text = _text;
    }
}
