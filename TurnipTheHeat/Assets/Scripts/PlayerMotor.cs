using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region Variables
    #endregion

    #region Methods
    void Start()
    {
		
	}
	
	void Update()
    {
		
	}

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");


    }
    #endregion
}
