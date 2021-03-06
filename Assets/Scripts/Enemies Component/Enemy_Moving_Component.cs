﻿using System.Collections;
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

    private int currentWayPoint;
    private bool pathIsEnded = true;
    private Vector3 destination;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartNewPath(target.position);
        }
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

        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        body.velocity = dir * speed * Time.fixedDeltaTime;
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if (dist < nextWaypointDistance)
        {
            currentWayPoint++;
            return;
        }
        return;
    }

    public void StartNewPath(Vector3 tar)
    {
        seeker.StartPath(transform.position, tar, OnPathComplete);
        destination = tar;
        pathIsEnded = false;
    }

    public void StopPathing()
    {
        pathIsEnded = true;
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("we got a path, did it have an error?" + p.error);
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

        seeker.StartPath(transform.position, destination, OnPathComplete);
        yield return new WaitForSeconds(1 / updateRate);
        StartCoroutine(UpdatePath());
    }

    public bool GetPathIsEnded()
    {
        return pathIsEnded;
    }

}
