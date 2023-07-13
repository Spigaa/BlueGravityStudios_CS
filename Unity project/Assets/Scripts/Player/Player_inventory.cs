using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_inventory : MonoBehaviour {
    public static Player_inventory _instance;

    Player_input _input;

    public Transform[] _slots;

    public static List<Clothes> _storedClothes = new List<Clothes>();
    private List<GameObject> _items = new List<GameObject>();

    public Clothes[] _allItems;
    public Clothes _defaultItem;

    private GameObject _inventoryGameObject;
    public GameObject _visual;

    private void Awake() {
        _storedClothes = new List<Clothes>();
        _items = new List<GameObject>();

        for (int i = 0; i < _allItems.Length; i++) {
            _allItems[i]._acquired = false;
        }
        _defaultItem._acquired = true;

        _instance = this;

        InitializeInventory();
    }

    private void Start() {
        _inventoryGameObject = transform.GetChild(0).gameObject;

        _inventoryGameObject.SetActive(false);
        _visual.SetActive(false);

        _input = Player_input._input;
    }
    

    public void GetItem(Clothes item) {
        for (int i = 0; i < _slots.Length; i++) {
            if (_slots[i].childCount == 0) {
                Instantiate(item._inventoryItem, _slots[i]);

                if (_slots[i].TryGetComponent(out ClothesSlot _cs)) {
                    _cs.CheckClothes(item);
                }
                break;
            }
        }
    }
    public void RemoveItem(Clothes item) {
        for (int i = 0; i < _slots.Length; i++) {
            if (_slots[i].childCount > 0) {
                if (_slots[i].GetChild(0).GetComponent<InventoryItem>()._item == item) {
                    Destroy(_slots[i].GetChild(0).gameObject);

                    if (_slots[i].TryGetComponent(out ClothesSlot _cs)) {
                        _cs.FoceSkinOff();
                    }
                    break;
                }
            }
        }
    }

    private void InitializeInventory() {
        for (int i = 0; i < _allItems.Length; i++) {
            if (_allItems[i]._acquired) {
                if (!_storedClothes.Contains(_allItems[i])) {
                    _storedClothes.Add(_allItems[i]);
                }
            }
        }        

        for (int i = 0; i < _storedClothes.Count; i++)  {
            if (_slots[i].childCount == 0) {
                _items.Add(Instantiate(_storedClothes[i]._inventoryItem, _slots[i]));
            }
        }
    }

    private void Update() {
        if (_input.InventoryInput()) {
            if (!_inventoryGameObject.activeSelf) {
                _inventoryGameObject.SetActive(true);
                _visual.SetActive(true);
            }
        }
        if (_input.ReturnInput()) {
            if (_inventoryGameObject.activeSelf)  {
                _inventoryGameObject.SetActive(false);
                _visual.SetActive(false);
            }
        }
    }
}
