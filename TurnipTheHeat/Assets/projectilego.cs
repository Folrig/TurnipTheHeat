using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilego : MonoBehaviour {

    Rigidbody rig;
    GameManager man;
	// Use this for initialization
	void Start () {

        man = FindObjectOfType<GameManager>();
        rig = GetComponent<Rigidbody>();


	}
	
	// Update is called once per frame
	void Update () {
        rig.AddForce(transform.forward * man.projspeed);

    }
}
