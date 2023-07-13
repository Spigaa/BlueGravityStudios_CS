using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {
    public static HUD instance;
    private void Awake() {
        instance = this;
    }

    [Header("UI")]
    public TextMeshProUGUI _coins;
    public TextMeshProUGUI _coinsTxt;
    public Animator _coinsAnim;

    public void UpdateCoins(int _value) {
        _coins.text = _value.ToString();
    }

    public void ConsumeAnimation() {
        _coinsAnim.SetTrigger("dec");

        _coinsTxt.text = "-";
    }
    public void AddAnimation() {
        _coinsAnim.SetTrigger("add");

        _coinsTxt.text = "+";
    }

    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() => SceneManager.LoadScene("Menu");
}
