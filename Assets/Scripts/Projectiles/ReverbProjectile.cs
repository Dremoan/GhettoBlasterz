using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbProjectile : Projectile {

    public int numberOfBoing = 2;

    private void OnEnable()
    {

    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer == 8)
        {
            if (numberOfBoing == 0)
                DropManagerComponent.RemoveDrop(this);
            else
                numberOfBoing--;
        }
    }

}
