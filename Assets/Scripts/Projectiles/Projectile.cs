using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float shootSpeed;
	public Rigidbody projectileBody;
    public float lifeTime = 1f;
    protected Vector3 shootDir;
	[HideInInspector]public bool dispo = true;

	private Vector3 dirToTarget;

	// Use this for initialization
	void OnEnable () 
	{
        if (gameObject.layer == 11) Debug.Log("that was an enemy projectile");
        Shoot();
        StartCoroutine(Life());
    }

	// Update is called once per frame
	void Update ()
    {

	}

	void Shoot()
	{
        projectileBody.AddForce(shootDir.normalized * shootSpeed, ForceMode.Impulse);
	}

    IEnumerator Life()
    {
        yield return new WaitForSeconds(lifeTime);
        DropManagerComponent.RemoveDrop(this);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer == 9)
        {
            DropManagerComponent.RemoveDrop(this);
            DropManagerComponent.RemoveEnemy(coll.gameObject.GetComponent<Enemy_Moving_Component>());
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 9)
        {
            DropManagerComponent.RemoveDrop(this);
            DropManagerComponent.RemoveEnemy(coll.gameObject.GetComponent<Enemy_Moving_Component>());
        }
    }

    public void SetDir(Vector3 dir)
    {
        shootDir = dir;
    }
}
