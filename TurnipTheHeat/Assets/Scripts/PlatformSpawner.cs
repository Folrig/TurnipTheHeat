using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject prefab = null;
    public bool gameStart = false;
    public float MinX = 1.0f;
    public float Easy = 6.0f;
    public float Medium = 4.0f;
    public float Hard = 2.0f;
    public float MaxX = 8.0f;
    public int counter = 0;

    // Use this for initialization]

    void Start () {
        StartCoroutine(DelayedSpawn(0.5f, 4f));
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
            if(counter <= 10)
            {
                go.transform.localScale = new Vector3(Mathf.Floor(Random.Range(Easy, MaxX)), 0.4f, 0.4f);
            }
            else if(counter <= 20)
            {
                go.transform.localScale = new Vector3(Mathf.Floor(Random.Range(Medium,Easy)), 0.4f, 0.4f);
            }
            else if(counter >= 35)
            {
                go.transform.localScale = new Vector3(Mathf.Floor(Random.Range(Hard, Medium)), 0.4f, 0.4f);
            }
            counter++;
            print(counter);
        }
    }
}
