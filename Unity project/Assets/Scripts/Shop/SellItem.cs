using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellItem : MonoBehaviour {
    public Clothes _item;

    private Button _btnSelect;
    private ShopUI _ui;

    void Start() {
        _btnSelect = GetComponent<Button>();
        _ui = ShopUI._ui;

        _ui._btnBuy.onClick.RemoveAllListeners();
        _btnSelect.onClick.AddListener(delegate { Select(); });
    }

    public void MouseOver()
    {
        CursorSet.ChangeCursor(CursorSet.CursorSelection.Selected);
    }
    public void MouseExit()
    {
        CursorSet.ChangeCursor(CursorSet.CursorSelection.Normal);
    }

    private void Select() {
        _ui.EnableBuyButton(false);

        _ui.UpdateItemValues(_item._name, _item._price.ToString(), _item._index);

        _ui._btnBuy.onClick.RemoveAllListeners();
        _ui._btnSell.onClick.RemoveAllListeners();
        _ui._btnSell.onClick.AddListener(delegate { Sell(); });
    }

    private void Sell() {
        Player_manager._manager.AddCoins(_item._price);

        Player_inventory._storedClothes.Remove(_item);

        Player_inventory._instance.RemoveItem(_item);
        ShopInventory._instance.RemoveItem(_item);

        HUD.instance.AddAnimation();

        _ui._itemName.text = "";
        _ui._itemPrice.text = "";

        _item._acquired = false;

        _btnSelect.interactable = false;
        _ui._btnSell.onClick.RemoveAllListeners();
        _ui._btnSell.interactable = false;
    }
}
