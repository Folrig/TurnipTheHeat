using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
    public float speed = 1.0f;
    GameManager control;
	// Use this for initialization
	void Start () {
        control = GameObject.FindObjectOfType<GameManager>();

        speed = (control.Timego * control.rate) + 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
