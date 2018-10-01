using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {
	[SerializeField] string _gameScene = "Game";
    [SerializeField] string _creditsScene = "Credits";
    [SerializeField] RectTransform _turnipMan = null;

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            Initiate();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            Quit();
        }
    }

    public void Initiate() {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() {
        float f = 2f;
        Vector3 target = _turnipMan.position;
        target.y = target.y - 100000f;
        while (f > 0f) {
            yield return null;
            _turnipMan.transform.position = Vector3.MoveTowards(_turnipMan.transform.position,target, 250 * Time.deltaTime);
            _turnipMan.transform.Rotate(0, 0, 60 * Time.deltaTime);
            f -= Time.deltaTime;
        }
        SceneManager.LoadScene(_gameScene);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
