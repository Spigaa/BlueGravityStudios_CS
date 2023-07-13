using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour {
    public static ShopUI _ui;

    [Header("Buttons")]
    public Button _btnInventorySlots;
    public Button _btnShopSlots;
    [Space(10)]
    public Button _btnBuy;
    public Button _btnSell;    

    private Image _btnInventorySlotsImage;
    private Image _btnShopSlotsImage;

    [Header("Slots")]
    public GameObject _inventorySlots;
    public GameObject _shopSlots;

    [Header("Item stats")]
    public TextMeshProUGUI _itemName;
    public TextMeshProUGUI _itemPrice;
    public SpriteRenderer _itemVisual;

    public Sprite[] _itemAppearance;

    private void Awake() {
        _ui = this;
    }
    private void Start() {
        _btnInventorySlotsImage = _btnInventorySlots.GetComponent<Image>();
        _btnShopSlotsImage = _btnShopSlots.GetComponent<Image>();

        _btnInventorySlots.onClick.AddListener(delegate { SelectInventorySlots(); });
        _btnShopSlots.onClick.AddListener(delegate { SelectShopSlots(); });
    }

    public void SelectInventorySlots() {
        _btnInventorySlotsImage.color = Color.green;
        _btnShopSlotsImage.color = Color.white;

        _inventorySlots.SetActive(true);
        _shopSlots.SetActive(false);
    }
    public void SelectShopSlots() {
        _btnShopSlotsImage.color = Color.green;
        _btnInventorySlotsImage.color = Color.white;

        _shopSlots.SetActive(true);
        _inventorySlots.SetActive(false);        
    }

    public void EnableBuyButton(bool enable) {
        _btnBuy.interactable = enable;
        _btnSell.interactable = !enable;
    }
    public void UpdateItemValues(string itemName, string itemPrice, int itemIndex) {
        _itemName.text = itemName;
        _itemPrice.text = itemPrice + " $";

        _itemVisual.sprite = _itemAppearance[itemIndex];
    }
}
