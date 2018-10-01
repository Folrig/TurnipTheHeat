using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facefire : MonoBehaviour {

    public GameObject dir;

    public Rigidbody proj;

     Transform cannon;

    GameManager man;
    float countdown;
	// Use this for initialization
	void Start () {
        man = FindObjectOfType<GameManager>();
        //countdown = man.porjtime;

        cannon = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(dir.transform);
        countdown -= Time.deltaTime;
        if (countdown<1 )
        {
            Rigidbody inst;
            inst = Instantiate(proj, cannon.position, cannon.rotation) as Rigidbody;
            //inst.AddForce(cannon.forward * man.projspeed);
            //countdown = man.porjtime;
            
        }
	}
}
