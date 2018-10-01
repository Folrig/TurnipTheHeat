using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    [SerializeField] string _bootScene = "Boot";
    [SerializeField] string _creditsScene = "Credits";

    private void Start()
    {
        GameManager.Instance.UnloadSingleton(true,true);
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            ReturnToStart();
        }
    }

    public void ReturnToStart() {
        SceneManager.LoadScene(_bootScene);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ViewCredits() {
        SceneManager.LoadScene(_creditsScene);
    }
}
