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
	void OnEnable () 
	{
        Shoot();
    }

	// Update is called once per frame
	void Update ()
    { 
	}

	void Shoot()
	{
        projectileBody.AddForce(transform.forward.normalized * shootSpeed, ForceMode.Impulse);
		if(Vector3.Distance(transform.position, launchPlace.transform.position) > 20)
		{
			DropManagerComponent.RemoveDrop (this);
		}
	}

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer == 9)
        {
            DropManagerComponent.RemoveDrop(this);
            DropManagerComponent.RemoveEnemy(coll.gameObject.GetComponent<Enemy_Moving_Component>());
        }
    }
}
