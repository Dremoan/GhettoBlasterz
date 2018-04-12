using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_manager : MonoBehaviour {

	public Cinemachine.CinemachineVirtualCamera Cam1;
	public Cinemachine.CinemachineVirtualCamera Cam2;

	void Update () {
		if (Input.GetAxis ("RightJoystickX") > 0)
		{ 
			Cam1.gameObject.SetActive (false);
			Cam2.gameObject.SetActive (true);
		}

		if (Input.GetAxis ("RightJoystickX") < 0)
		{ 
			Cam1.gameObject.SetActive (true);
			Cam2.gameObject.SetActive (false);
		}
		
	}
}
