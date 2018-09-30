using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
    public float speed = 1.0f;
    public float platformMinXSize = 3.0f;
    public float platformMaxXSize = 7.0f;
    public float platformYSize = 0.4f;
    public float platformZSize = 1.0f;
    public Vector3 platformSize;

    private void Awake()
    {
        platformSize = new Vector3(Random.Range(platformMinXSize, platformMaxXSize), platformYSize, platformZSize);
        gameObject.transform.localScale = platformSize;
    }
    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


}
