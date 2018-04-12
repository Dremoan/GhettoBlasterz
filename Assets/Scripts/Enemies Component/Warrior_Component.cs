using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Moving_Component))]
public class Warrior_Component : MonoBehaviour {

    public Transform playerTransform;
    public Rigidbody body;
    public float dashForce = 700;
    public float dashDelay = 1.5f;
    public float distToDash = 5f;
    public Enemy_Moving_Component pathFinder;
    public AiDirectionFinder_Comp directionFinder;

    private bool attacking = false;

    private void Update()
    {
        FaceTarget();
        if(Vector3.Distance(transform.position, playerTransform.position) <= distToDash && !attacking && directionFinder.IsFrontTrajectoryCleared())
        {
            pathFinder.StopPathing();
            Dash();
        }
    }

    private void FaceTarget()
    {
        Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;
        float rot_Y = Mathf.Atan2(dirToPlayer.z, dirToPlayer.x) * Mathf.Rad2Deg;
        Debug.Log(rot_Y);
        transform.rotation = Quaternion.Euler(0, -rot_Y, 0);
    }

    private void Dash()
    {
        pathFinder.StopPathing();
        attacking = true;
        Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;
        body.AddForce(dirToPlayer.normalized * dashForce);
        StartCoroutine(DashDelay());
    }

    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(dashDelay);
        pathFinder.StartNewPath();
        attacking = false;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(attacking && coll.gameObject.GetComponent<MoveScript>() != null)
        {
            //hurt the player;
        }
    }

}
