using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject prefab = null;
    public float MinX = 1.5f;
    public float MaxX = 8.0f;

    // Use this for initialization]

    void Start () {
        StartCoroutine(DelayedSpawn(2f, 4f));
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 7.5f,0.0f);
    }

    IEnumerator DelayedSpawn(float minTime, float maxTime) {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(minTime);
            GameObject go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
            go.transform.localScale = new Vector3(Random.Range(MinX,MaxX),0.4f,0.4f);
        }
    }
}
