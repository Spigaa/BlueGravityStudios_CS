using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Toggle _toggle;

    private void Start() {
        _toggle.isOn = false;
        Screen.fullScreen = false;
    }

    public void StartGame() => SceneManager.LoadScene("Shop");

    public void QuitGame() => Application.Quit();    

    public void SetFullscreen() => Screen.fullScreen = !Screen.fullScreen;
}
