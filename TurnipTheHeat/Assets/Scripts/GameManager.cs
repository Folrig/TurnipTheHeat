using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float timer;
    public float speed;
    public float rate;

    bool timegogo;
    protected override void Initiate()
    {
        timegogo = true;
       

    }
    private void Update()
    {
        if (timegogo)
        {
            timer += Time.deltaTime;

            
        }

        Mathf.Clamp(speed, 0, 10);
    }

}	
