using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject prefab = null;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(DelayedSpawn(1f, 2f));
	}
	
	// Update is called once per frame
	void Update ()
    {
  
    }

    IEnumerator DelayedSpawn(float minTime, float maxTime) {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(minTime);
            Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
