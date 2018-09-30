using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float timer;
    public float speed;
    public float rate;

<<<<<<< HEAD
    bool timegogo;

    public float projspeed;

    public float porjtime;
=======
   public bool timegogo;
>>>>>>> 7f796154679884755fd5cb12d6a0b785eef8fbee
    protected override void Initiate()
    {
        
        timegogo = false;

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
