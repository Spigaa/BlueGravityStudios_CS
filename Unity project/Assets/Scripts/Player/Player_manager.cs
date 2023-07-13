using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_manager : MonoBehaviour {
    public static Player_manager _manager;
    private void Awake() => _manager = this;

    [HideInInspector] public Clothes _equippedCloth;

    private HUD _hud;
    private Player_animator _anim;

    public int _coins;

    [Header("Player")]
    public SpriteRenderer _skin;

    private void Start() {
        _hud = HUD.instance;
        _anim = GetComponent<Player_animator>();

        _hud.UpdateCoins(_coins);
    }

    public void ConsumeCoins(int value) {
        _coins -= value;
        _hud.UpdateCoins(_coins);
    }
    public void AddCoins(int value) {
        _coins += value;
        _hud.UpdateCoins(_coins);
    }

    public void EquipItem(Clothes item) {
        _skin.enabled = true;
        _equippedCloth = item;

        _skin.sprite = _equippedCloth._skin;
        ChangeClothesAnimation();
    }
    public void RemoveClothes() {
        _skin.enabled = false;
    }

    public void ChangeClothesAnimation() {
        _anim._anim[1].runtimeAnimatorController = _equippedCloth._clothesAnimation;
    }
}
