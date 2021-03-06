using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeScript : MonoBehaviour {

	public float magnitude;
	public float roughness;
	public float fadeInTime;
	public float fadeOutTime;
	public ParticleSystem ripple;

	void Start () {
		
	}
	

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			ripple.Play ();
			CameraShake ();
		}
	}

	void CameraShake()
	{
		CameraShaker.Instance.ShakeOnce (magnitude, roughness, fadeInTime, fadeOutTime);
	}
}
