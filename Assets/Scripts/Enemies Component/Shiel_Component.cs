using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiel_Component : MonoBehaviour {

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer == 10)
        {
            DropManagerComponent.RemoveDrop(coll.GetComponent<Projectile>());
        }
    }

}
