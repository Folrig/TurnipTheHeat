using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrig : MonoBehaviour {

    GameManager man;
	// Use this for initialization
	void Start () {
        man = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        man.timegogo = true ;
    }
}
