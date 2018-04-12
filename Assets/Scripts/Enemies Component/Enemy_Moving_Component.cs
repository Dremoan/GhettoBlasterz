
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy_Moving_Component : MonoBehaviour {

    public Transform target;
    public float updateRate = 2f;
    public Seeker seeker;
    public Rigidbody body;

    public Path path;
    public float speed = 100f;
    public float nextWaypointDistance = 3f;

    [HideInInspector] public bool dispo = true;
    private int currentWayPoint;
    private bool pathIsEnded = true;

    private void OnEnable()
    {
        pathIsEnded = true;
        path = null;
        StartNewPath();
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;
        if (path == null)
            return;
        if(currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized * speed * Time.fixedDeltaTime;
        if(body.velocity.magnitude < dir.magnitude)
        {
            body.velocity += dir - body.velocity;
        }
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if (dist < nextWaypointDistance)
        {
            currentWayPoint++;
            return;
        }
        return;
    }

    public void StartNewPath()
    {
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        pathIsEnded = false;
        StartCoroutine(UpdatePath());
    }

    public void StopPathing()
    {
        path = null;
    }

    public void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
            yield break;

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1 / updateRate);
        if (path == null)
            yield break;
        StartCoroutine(UpdatePath());
    }

    public bool GetPathIsEnded()
    {
        return pathIsEnded;
    }

}
