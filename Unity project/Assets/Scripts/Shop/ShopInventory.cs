using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour {
    public static ShopInventory _instance;

    private List<GameObject> _items = new List<GameObject>();

    public Transform[] _slots;

    private void Awake() {
        _instance = this;
    }
    private void Start() {
        InitializeInventory();
    }

    public void GetItem(Clothes item) {
        for (int i = 0; i < Player_inventory._storedClothes.Count; i++) {
            if (_slots[i].childCount == 0) {
                Instantiate(item._shopItem, _slots[i]);
            }
        }
    }
    public void RemoveItem(Clothes item) {
        for (int i = 0; i < Player_inventory._instance._slots.Length; i++) {
            if (_slots[i].childCount > 0) {
                if (_slots[i].GetChild(0).GetComponent<SellItem>()._item == item) {
                    Destroy(_slots[i].GetChild(0).gameObject);
                    break;
                }
            }
        }
    }

    private void InitializeInventory() {
        for (int i = 0; i < Player_inventory._storedClothes.Count; i++) {
            if (_slots[i].childCount == 0) {
                _items.Add(Instantiate(Player_inventory._storedClothes[i]._shopItem, _slots[i]));
            }
        }
    }
}
