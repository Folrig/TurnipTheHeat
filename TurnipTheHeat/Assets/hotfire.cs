using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotfire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player Placeholder")
        {
            Debug.Log("isin");
        }
    }
     void OnTriggerExit(Collider other)
    {
        Debug.Log("isout");

    }
}
