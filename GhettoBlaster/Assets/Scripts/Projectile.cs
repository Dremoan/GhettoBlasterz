using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float shootSpeed;
	public Rigidbody projectileBody;
	public GameObject launchPlace;
	[HideInInspector]public bool dispo = true;


	private Vector3 dirToTarget;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		Shoot ();
	}

	void Shoot()
	{
		projectileBody.velocity = transform.forward.normalized * shootSpeed * Time.fixedDeltaTime;
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > 20)
		{
			DropManagerComponent.RemoveDrop (this);
		}
	}
}
