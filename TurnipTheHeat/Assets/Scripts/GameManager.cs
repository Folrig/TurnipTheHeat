using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float timer;
    public float speed;
    public float waveOneTime = 15.0f;
    public float waveTwoTime = 30.0f;
    public float waveThreeTime = 45.0f;
    public float waveFourTime = 60.0f;
    public bool isLevelTwo = false;
    public bool isLevelThree = false;
    public bool isLevelFour = false;

    public float projectile_Spawntime;
    public float Projectile_countdown;
    public float projectile_Speed;

    public facefire Left;
    public facefire Right;
   enum LR { left, Right };
    LR turret_rotation;

    protected override void Initiate()
    {

        speed = 2.0f;
        Projectile_countdown = projectile_Spawntime;
    }



    private void Update()
    {
        timer += Time.deltaTime;
        Projectile_countdown -= Time.deltaTime;


        if (timer >= waveOneTime && isLevelTwo == false)
        {
            speed = 2.25f;
            isLevelTwo = true;
        }
        if (timer >= waveTwoTime && isLevelThree == false)
        {
            speed = 3.25f;
            isLevelThree = true;
        }
        if (timer >= waveThreeTime && isLevelFour == false)
        {
            speed = 4.25f;
            isLevelFour = true;
        }
        if (timer >= waveFourTime)
        {
            speed = 5.0f;
        }


        if (Projectile_countdown < 1)
        {
            turretswitch();
            Projectile_countdown = projectile_Spawntime;


        }


    }
    public void turretswitch()
    {
        switch (turret_rotation)
        {
            case LR.left:
                turret_rotation = LR.Right;
                Right.Fire();
                break;
            case LR.Right:
                turret_rotation = LR.left;
                Left.Fire();
                break;

        }
    }
}
