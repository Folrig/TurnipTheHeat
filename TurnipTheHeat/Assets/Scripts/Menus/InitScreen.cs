using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScreen : MonoBehaviour {
    private void Awake() {
        StartCoroutine(WaitNGo());
    }

    IEnumerator WaitNGo() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Boot");
    }
}
