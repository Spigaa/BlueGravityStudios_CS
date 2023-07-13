using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Clothes")]
public class Clothes : ScriptableObject {

    public Sprite _skin;

    [Header("UI")]
    public GameObject _inventoryItem;
    public GameObject _shopItem;

    [Header("Attributes")]
    public string _name;
    public int _price;

    [Header("Components")]
    public int _index;
    public RuntimeAnimatorController _clothesAnimation;

    [Space(20)]
    public bool _acquired = false;
}
