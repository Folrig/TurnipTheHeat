using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {


    GameManager man;
	void Start () {

        man = FindObjectOfType<GameManager>();

        man.speed = (man.Timego * man.rate) + 1.0f;

    }

    // Update is called once per frame
    void Update ()
    {
        gameObject.transform.Translate(Vector3.down * man.speed * Time.deltaTime);
	}
}
