using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float Timego;

    public float rate;

    public float speed;

    bool timegogo;
    protected override void Initiate()
    {
        timegogo = true;
       

    }
    private void Update()
    {
        if (timegogo)
        {
            Timego += Time.deltaTime;

            
        }

        Mathf.Clamp(speed, 0, 10);
    }

}	
