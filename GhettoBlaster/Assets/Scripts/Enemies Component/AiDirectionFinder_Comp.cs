using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDirectionFinder_Comp : MonoBehaviour {

    public float width = 1f;
    public float range = 5f;
    public LayerMask mask;
    private Vector3 dirFront;
    private Vector3 dirRight;
    private Vector3 dirLeft;
    private Vector3 dirBack;
    private Vector3 testDir = Vector2.up;

    private void Update()
    {
        dirFront = transform.right;
        dirRight = -transform.forward;
        dirLeft = transform.forward;
        dirBack = -transform.right;

        Debug.DrawLine(transform.position, transform.position + dirFront, Color.blue);
        Debug.DrawLine(transform.position, transform.position + dirRight, Color.green);
        Debug.DrawLine(transform.position, transform.position + dirLeft, Color.red);
        Debug.DrawLine(transform.position, transform.position + dirBack, Color.white);

        Debug.DrawLine(transform.position, transform.position + (testDir.normalized * range), Color.magenta);
    }

    // front = right, up = up;

    //back += left
    //left += front
    //front += right
    //right += back

    public Vector3 GetBackDirection() // direction tourne vers le rayon le plus distant
    {
        Vector3 direction = dirBack;
        RaycastHit2D hitOne = Physics2D.Raycast(transform.position + (dirLeft * width), dirBack, range, mask);
        RaycastHit2D hitTwo = Physics2D.Raycast(transform.position + (dirRight * width), dirBack, range, mask);
        if(hitOne.collider != null || hitTwo.collider != null) // si l'un des 2 à touché un mur
        {
            direction = (direction + dirRight).normalized;
            testDir = direction;
            return direction;
        }
        testDir = direction;
        return dirBack;
    }

    public Vector3 GetRightDirection() // tourne vers l'arrière si l'espace n'est pas libre
    {
        Vector3 direction = dirRight;
        bool hitOne = Physics.Raycast(transform.position + (dirFront * width), dirRight, range, mask);
        bool hitTwo = Physics.Raycast(transform.position + (dirBack * width), dirRight, range, mask);
        if(hitOne || hitTwo)
        {
            direction = dirLeft.normalized;
            testDir = direction;
            return direction;
        }
        testDir = direction;
        return dirRight;
    }

    public Vector3 GetLeftDirection() // tourne vers l'arrière si l'espace n'est pas libre
    {
        Vector3 direction = dirLeft;
        bool hitOne = Physics.Raycast(transform.position + (dirFront * width), dirLeft, range, mask);
        bool hitTwo = Physics.Raycast(transform.position + (dirBack * width), dirLeft, range, mask);
        if (hitOne || hitTwo)
        {
            direction = dirRight.normalized;
            testDir = direction;
            return direction;
        }
        testDir = direction;
        return dirLeft;
    }

    public bool IsFrontTrajectoryCleared() // test pour savoir si il y a des obstacle devant le mob, peu importe la distance
    {
        bool hit = Physics.Raycast(transform.position, dirFront, range, mask);
        if (hit) return false;
        else return true;
    }

    public Vector3 GetFrontDirection() // direction tourne vers le rayon le plus distant
    {
        Vector3 direction = dirFront;
        bool hitOne = Physics.Raycast(transform.position + (dirLeft * width), dirFront, range, mask);
        bool hitTwo = Physics.Raycast(transform.position + (dirRight * width), dirFront, range, mask);
        if (hitOne || hitTwo) // si l'un des 2 ou les 2 à touché un mur
        {

            direction = (direction + dirLeft).normalized;
            testDir = direction;
            return direction;
        }
        testDir = direction;
        return dirFront;
    }

    private Vector3 ResetDirectionToRange(Vector3 vectorToReset)
    {
        vectorToReset = vectorToReset.normalized * range;
        return vectorToReset;
    }

    public void SetValues(float w, float r, LayerMask m)
    {
        width = w;
        range = r;
        mask = m;
    }
}
