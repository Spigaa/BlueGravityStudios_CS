using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour {
    [SerializeField] private Clothes _item;

    private Button _btnSelect;
    private ShopUI _ui;

    void Start() {
        _btnSelect = GetComponent<Button>();
        _ui = ShopUI._ui;

        if (_item._acquired) {
            _btnSelect.interactable = false;
            return;
        }

        _ui._btnBuy.onClick.RemoveAllListeners();
        _btnSelect.onClick.AddListener(delegate { Select(); });
    }

    public void MouseOver() {
        CursorSet.ChangeCursor(CursorSet.CursorSelection.Selected);
    }
    public void MouseExit() {
        CursorSet.ChangeCursor(CursorSet.CursorSelection.Normal);
    }

    private void Select() {
        _ui.EnableBuyButton(true);

        _ui.UpdateItemValues(_item._name, _item._price.ToString(), _item._index);

        _ui._btnSell.onClick.RemoveAllListeners();
        _ui._btnBuy.onClick.RemoveAllListeners();
        _ui._btnBuy.onClick.AddListener(delegate { CheckFunds(); });
    }
    private void CheckFunds() {
        if (Player_manager._manager._coins >= _item._price) {
            Buy();
        }                
    }

    private void Buy() {
        Player_manager._manager.ConsumeCoins(_item._price);

        Player_inventory._storedClothes.Add(_item);

        Player_inventory._instance.GetItem(_item);
        ShopInventory._instance.GetItem(_item);

        HUD.instance.ConsumeAnimation();

        _item._acquired = true;

        _btnSelect.interactable = false;
        _ui._btnBuy.onClick.RemoveAllListeners();
        _ui._btnBuy.interactable = false;
    }
}
