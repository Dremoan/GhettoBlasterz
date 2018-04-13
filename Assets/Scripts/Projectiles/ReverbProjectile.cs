using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbProjectile : Projectile {

    public int numberOfBoing = 2;
    private int initialNumber;

    private void Start()
    {
        initialNumber = numberOfBoing;
    }

    private void OnDisable()
    {
        numberOfBoing = initialNumber;
        projectileBody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 9)
        {
            DropManagerComponent.RemoveDrop(this);
            DropManagerComponent.RemoveEnemy(coll.gameObject.GetComponent<Enemy_Moving_Component>());
        }

        if (coll.gameObject.layer == 8)
        {
            if (numberOfBoing == 0)
                DropManagerComponent.RemoveDrop(this);
            else
                numberOfBoing--;
        }
    }

}
