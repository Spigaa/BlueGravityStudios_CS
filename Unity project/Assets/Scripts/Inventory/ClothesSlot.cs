using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClothesSlot : MonoBehaviour, IDropHandler {
    public static ClothesSlot _slot;

    private void Awake() => _slot = this;

    public SpriteRenderer _skin;
    public Sprite[] _clothesIndex;

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            _skin.enabled = true;

            InventoryItem _inv = eventData.pointerDrag.GetComponent<InventoryItem>();
            _inv._slotToDrag = transform;

            _skin.sprite = _clothesIndex[_inv._item._index];

            Player_manager._manager.EquipItem(_inv._item);
        }
        else {
            _skin.enabled = true;

            InventoryItem _inv = eventData.pointerDrag.GetComponent<InventoryItem>();

            Transform t = transform.GetChild(0);
            t.SetParent(_inv._slotToDrag);

            _inv._slotToDrag = transform;

            _skin.sprite = _clothesIndex[_inv._item._index];

            Player_manager._manager.EquipItem(_inv._item);
        }
    }

    public void CheckClothes(Clothes _inv) {
        _skin.enabled = true;

        _skin.sprite = _clothesIndex[_inv._index];

        Player_manager._manager.EquipItem(_inv);
    }

    public void ResetSkin() {
        if (transform.childCount == 0) {
            _skin.enabled = false;

            Player_manager._manager.RemoveClothes();
        }        
    }

    public void FoceSkinOff() {
        _skin.enabled = false;

        Player_manager._manager.RemoveClothes();
    }
}
