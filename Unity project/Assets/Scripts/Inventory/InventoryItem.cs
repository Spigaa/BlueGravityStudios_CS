using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Clothes _item;

    Image _img;
    [HideInInspector] public Transform _slotToDrag;


    private void Awake() {
        _img = GetComponent<Image>();
    }

    public void MouseOver() {
        CursorSet.ChangeCursor(CursorSet.CursorSelection.Selected);
    }
    public void MouseExit() {
        CursorSet.ChangeCursor(CursorSet.CursorSelection.Normal);
    }

    public void OnBeginDrag(PointerEventData eventData) {        
        InventoryItem[] _items = FindObjectsOfType<InventoryItem>();
        foreach (InventoryItem it in _items) {
            it.SetImageRaycast(false);
        }
        SetImageRaycast(false);

        _slotToDrag = transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData) {
        Vector3 worldPosition;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0;

        transform.position = worldPosition;
    }
    public void OnEndDrag(PointerEventData eventData) {
        InventoryItem[] _items = FindObjectsOfType<InventoryItem>();
        foreach (InventoryItem it in _items) {
            it.SetImageRaycast(true);
        }
        SetImageRaycast(true);

        transform.SetParent(_slotToDrag);
    }  

    public void SetImageRaycast(bool _condition) {
        _img.raycastTarget = _condition;
    }
}