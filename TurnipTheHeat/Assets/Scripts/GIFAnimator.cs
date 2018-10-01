using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIFAnimator : MonoBehaviour
{
    [SerializeField] private Texture2D[] _frames;
    [SerializeField] private float _FPS = 10.0f;

    private Material _turnipFrames;

	void Start()
    {
        _turnipFrames = GetComponent<Renderer>().material;
	}
	
	void Update()
    {
        int frameIndex = (int)(Time.time * _FPS);
        frameIndex = frameIndex % _frames.Length;
        _turnipFrames.mainTexture = _frames[frameIndex];
	}
}
