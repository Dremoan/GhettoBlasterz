using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyActivator : MonoBehaviour {

    public Rigidbody body;

    public void ActivateBody()
    {
        body.isKinematic = false;
    }

}
