﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float Timego;

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
            Timego += Time.deltaTime;

            
        }
        Mathf.Round(Timego);

    }

}	
