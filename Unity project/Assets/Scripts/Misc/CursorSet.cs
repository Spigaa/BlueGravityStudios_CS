using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSet : MonoBehaviour {

    public Texture2D _cursorNormal;
    public Texture2D _cursorSelected;
    public Texture2D _cursorClicked;

    public static Texture2D _cursorNormalS;
    public static Texture2D _cursorSelectedS;
    public static Texture2D _cursorClickedS;

    public enum CursorSelection { Normal, Selected, Clicked }
    public static CursorSelection _cursorMode;

    private void Awake() {
        _cursorNormalS = _cursorNormal;
        _cursorSelectedS = _cursorSelected;
        _cursorClickedS = _cursorClicked;

        ChangeCursor(CursorSelection.Normal);
    }

    public static void ChangeCursor(CursorSelection _mode) {
        if (_mode == CursorSelection.Normal) {
            Cursor.SetCursor(_cursorNormalS, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (_mode == CursorSelection.Selected) {
            Cursor.SetCursor(_cursorSelectedS, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    private void LateUpdate() {
        if (Input.GetMouseButtonDown(0)) 
            Cursor.SetCursor(_cursorClickedS, Vector2.zero, CursorMode.ForceSoftware);        
        if (Input.GetMouseButtonUp(0))
            Cursor.SetCursor(_cursorNormalS, Vector2.zero, CursorMode.ForceSoftware);
    }
}
