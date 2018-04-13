using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeScript : MonoBehaviour {

	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;
	public CameraShaker scriptShake;

	void Start () {
		
	}
	

	void Update ()
	{

	}

	public void CameraShake()
	{
		CameraShaker.Instance.ShakeOnce (magnitude, roughness, fadeInTime, fadeOutTime);
	}
}
