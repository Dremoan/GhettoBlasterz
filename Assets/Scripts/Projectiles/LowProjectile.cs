﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowProjectile : Projectile {

    public float waveForcePlayer = 50f;
    public float waveForceEnemy = 150f;
    public float waveForceOther = 150f;
    public float waveRadius = 3f;
    public LayerMask affectedLayers;

    IEnumerator Shield()
    {
        yield return new WaitForSeconds(0);
        Pulse();
    }

    private void OnEnable()
    {
        if (gameObject.layer == 11) Debug.Log("that was an enemy projectile");
        Shoot();
        StartCoroutine(Life());
        StartCoroutine(Shield());
    }

    private void Pulse()
    {
        Collider[] results = Physics.OverlapSphere(transform.position, waveRadius * 2, affectedLayers);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<Rigidbody>() != null)
            {
                if (results[i].gameObject.layer == 9)
                {
                    results[i].GetComponent<Rigidbody>().AddExplosionForce(waveForceEnemy, transform.position, waveRadius);
                }
                else if (results[i].gameObject.layer == 12)
                {
                    results[i].GetComponent<Rigidbody>().AddExplosionForce(waveForcePlayer, transform.position, waveRadius);
                }
                else
                {
                    results[i].GetComponent<Rigidbody>().AddExplosionForce(waveForcePlayer, transform.position, waveRadius);
                }
            }
        }
    }
}
