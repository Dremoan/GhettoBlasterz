﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    public GameObject enceintes;

    private float counter = 1;

	void Update () 
	{
		SwitchBullets();
	}

	void SwitchBullets()
	{
		if(Input.GetButtonDown("RightBumper"))
		{
			counter = counter + 1;
		}
		if(Input.GetButtonDown("LeftBumper"))
		{
			counter = counter - 1;
		}

		if(counter > 3 && Input.GetButtonDown("RightBumper"))
		{
			counter = 1;
		}
		if(counter < 1 && Input.GetButtonDown("LeftBumper"))
		{
			counter = 3;
		}
	}

    public float GetCounter()
    {
        return counter;
    }

	public bool Shoot()
	{
        if(Input.GetAxis("RightTrigger") > 0.1f)
        {
            return true;
        }else
        {
            return false;
        }
	}

    public void BeatShoot()
    {
        if (Shoot())
        {
            if (counter == 1)
                DropManagerComponent.SpawnDropLow(enceintes.transform.position, transform.eulerAngles.y + 90);
            else if (counter == 2)
                DropManagerComponent.SpawnDropMedium(enceintes.transform.position, transform.eulerAngles.y + 90);
            else if (counter == 3)
                DropManagerComponent.SpawnDropHigh(enceintes.transform.position, transform.eulerAngles.y + 90);
        }
    }
}
