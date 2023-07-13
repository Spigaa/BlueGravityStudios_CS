using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_input : MonoBehaviour {
    public static Player_input _input;
    private void Awake() => _input = this;  

    [Header("Key binds")]
    public KeyCode _interactionInput = KeyCode.E;
    public KeyCode _inventoryInput = KeyCode.I;
    public KeyCode _returnInput = KeyCode.Escape;

    public Vector2 MovementInput() {
        if (Player_movement._paused)
            return Vector2.zero;
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    public bool InteractionInput() {
        if (Player_movement._paused)
            return false;
        return Input.GetKeyDown(_interactionInput);
    }

    public bool InventoryInput() {
        return Input.GetKeyDown(_inventoryInput);
    }
    public bool ReturnInput() {
        return Input.GetKeyDown(_returnInput);
    }
}
