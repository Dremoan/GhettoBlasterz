using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Moving_Component))]
public class Warrior_Component : MonoBehaviour {

    public Transform playerTransform;
    public Rigidbody body;
    public float dashForce = 700;
    public float dashDelay = 1.5f;
    public GameObject attaqueBox;
    public float distToDash = 5f;
    public Enemy_Moving_Component pathfinder;

    private void Update()
    {
        FaceTarget();
    }

    private void FaceTarget()
    {
        Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;
        float rot_Y = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;
    }

    private void Dash()
    {
        attaqueBox.SetActive(true);
        Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;
        body.AddForce(dirToPlayer.normalized * dashForce);
    }

    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(dashDelay);
        pathfinder.StartNewPath(playerTransform.position);
    }

}
