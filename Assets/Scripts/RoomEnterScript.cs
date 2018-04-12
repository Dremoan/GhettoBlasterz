using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterScript : MonoBehaviour {

    public GameEvent entrance;
    private bool entered = false;

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer == 12 && !entered)
        {
            entrance.Raise();
            entered = true;
        }
    }

}
