using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {


    GameManager gameManager;
	void Start ()
    {

        gameManager = FindObjectOfType<GameManager>();

        gameManager.speed = (gameManager.timer * gameManager.rate) + 1.0f;
    }

    // Update is called once per frame
    void Update ()
    {
        gameObject.transform.Translate(Vector3.down * gameManager.speed * Time.deltaTime);
	}
}
