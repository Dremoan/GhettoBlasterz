using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {


	public float counter = 1;

	void Update () 
	{
		Shoot ();
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
		if (counter < 1 && Input.GetButtonDown("LeftBumper"))
		{
			counter = 3;
		}
	}

	void Shoot()
	{
		if(Input.GetAxis("RightTrigger") > 0.1f && counter == 1)
		{
				DropManagerComponent.SpawnDropLow (transform.position, transform.eulerAngles.y + 90);
		}
		if(Input.GetAxis("RightTrigger") > 0.1f && counter == 2)
		{
			DropManagerComponent.SpawnDropMedium (transform.position, transform.eulerAngles.y + 90);
		}	
		if(Input.GetAxis("RightTrigger") > 0.1f && counter == 3)
		{
			DropManagerComponent.SpawnDropHigh (transform.position, transform.eulerAngles.y + 90);
		}
	}
}
