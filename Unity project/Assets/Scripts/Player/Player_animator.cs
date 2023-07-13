using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animator : MonoBehaviour {
    private Player_input _input;
    private Player_manager _manager;

    public Animator[] _anim;

    private void Awake() {
        _input = GetComponent<Player_input>();
        _manager = GetComponent<Player_manager>();
    }
    private void Start() {
        _anim[1].runtimeAnimatorController = _manager._equippedCloth._clothesAnimation;
    }

    private void HandleAnimations() {
        foreach (Animator anm in _anim) {
            if (_input.MovementInput() != Vector2.zero)
            {
                anm.SetFloat("horizontal", _input.MovementInput().x);
                anm.SetFloat("vertical", _input.MovementInput().y);
            }

            anm.SetBool("moving", _input.MovementInput() != Vector2.zero);
        }        
    }

    void Update() {
        HandleAnimations();
    }
}
