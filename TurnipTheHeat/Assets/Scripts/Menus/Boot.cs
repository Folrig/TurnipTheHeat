using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {
	[SerializeField] string _gameScene = "Game";
    [SerializeField] string _creditsScene = "Credits";

    public void Initiate() {
        SceneManager.LoadScene(_gameScene);
    }

    public void Quit() {
        Application.Quit();
    }
}
