using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour {
    private Player_input _input;
    private Player_movement _movement;
    private Player_interaction _interaction;

    private bool _onTrigger;

    [Header("Dialogue")]
    public Animator _anim;

    [Header("Shop UI")]
    public GameObject _canvas;

    [Header("Events")]
    public UnityEvent _onShopEnter;
    public UnityEvent _onShopExit;

    private void Start() {
        _input = Player_input._input;
        _movement = Player_movement._movement;
        _interaction = Player_interaction._interaction;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _onTrigger = true;

            SetDialogueBox("_dialogueOn");

            _interaction.InteractableFound(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _onTrigger = false;

            SetDialogueBox("_dialogueOff");

            _interaction.InteractableFound(false);
        }
    }

    private void SetDialogueBox(string _triggerName) {
        _anim.SetTrigger(_triggerName);
    }

    private void CheckPlayer() {
        if (_onTrigger) {
            if (_input.InteractionInput()) {
                OpenShop();
            }
        }
    }

    private void OpenShop() {
        _movement.PausePlayer(true);

        _canvas.SetActive(true); 

        _onShopEnter.Invoke();
    }
    public void CloseShop() {
        _movement.PausePlayer(false);

        _canvas.SetActive(false);

        _onShopExit.Invoke();
    }

    private void Input() {
        if (_canvas.activeSelf) {
            if (_input.ReturnInput()) {
                CloseShop();
            }
        }
    }

    private void Update() {
        CheckPlayer();

        Input();
    }
}
