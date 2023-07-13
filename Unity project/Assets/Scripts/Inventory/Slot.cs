using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

    public UnityEvent _onDrop;

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            InventoryItem _inv = eventData.pointerDrag.GetComponent<InventoryItem>();
            _inv._slotToDrag = transform;

            _onDrop.Invoke();
        }
        else {
            InventoryItem _inv = eventData.pointerDrag.GetComponent<InventoryItem>();

            Transform t = transform.GetChild(0);
            InventoryItem _inv2 = t.GetComponent<InventoryItem>();
            ClothesSlot._slot.CheckClothes(_inv2._item);

            t.SetParent(_inv._slotToDrag);
            
            _inv._slotToDrag = transform;
        }
    }
}
