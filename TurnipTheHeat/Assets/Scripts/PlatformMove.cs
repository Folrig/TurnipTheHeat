using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update ()
    {
        gameObject.transform.Translate(Vector3.down * gameManager.speed * Time.deltaTime);
	}
}
