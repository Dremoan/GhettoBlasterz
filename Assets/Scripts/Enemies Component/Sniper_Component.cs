﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Component : MonoBehaviour {

    public Transform playerTransform;
    public Rigidbody body;
    public float distToShoot = 30f;
    public float walkShootingSpeed = 100f;
    public Enemy_Moving_Component pathFinder;
    public AiDirectionFinder_Comp directionFinder;

    private Coroutine rounding;
    private bool activatePathing = true;
    private bool attacking;
    private bool right;

    private void Start()
    {
        rounding = StartCoroutine(GoRounding());
    }

    private void Update()
    {
        FaceTarget();
        float distToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distToPlayer < distToShoot + 1 && distToPlayer > distToPlayer -1)
        {
            attacking = true;
            if(activatePathing)
            {
                activatePathing = false;
                pathFinder.StopPathing();
            }
            if (right) body.velocity = directionFinder.GetRightDirection().normalized * walkShootingSpeed * Time.fixedDeltaTime;
            else body.velocity = directionFinder.GetLeftDirection().normalized * walkShootingSpeed * Time.fixedDeltaTime;
        }
        else
        {
            attacking = false;
            if (!activatePathing)
            {
                activatePathing = true; ;
                pathFinder.StartNewPath();
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;
        float rot_Y = Mathf.Atan2(dirToPlayer.z, dirToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -rot_Y, 0);
    }

    public void BeatShoot()
    {
        if (!attacking)
            return;
        Debug.Log("shot!");
        // pool array to spawn projectile
    }

    IEnumerator GoRounding()
    {
        right = (Random.Range(0, 2) == 1) ? true : false;
        yield return new WaitForSeconds(3f);
        rounding = StartCoroutine(GoRounding());
    }

}
