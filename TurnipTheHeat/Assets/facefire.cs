using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facefire : MonoBehaviour {

    public GameObject dir;

    public Rigidbody proj;

     Transform cannon;

    GameManager man;


	// Use this for initialization
	void Start () {
        man = FindObjectOfType<GameManager>();

        cannon = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(dir.transform);                    
           
            
        	}
    public void Fire()
    {
        Rigidbody inst;
        inst = Instantiate(proj, cannon.position, cannon.rotation) as Rigidbody;
        inst.AddForce(cannon.forward * man.projectile_Speed);
    }
}
