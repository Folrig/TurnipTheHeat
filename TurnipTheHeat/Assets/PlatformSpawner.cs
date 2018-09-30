using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject prefab;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(DelayedSpawn(2f, 4f));
	}
	
	// Update is called once per frame
	void Update ()
    {
         transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 7.5f, 0);
    }

    void NewSpawnLocation()
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
