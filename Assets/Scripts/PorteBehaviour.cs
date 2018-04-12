using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteBehaviour : MonoBehaviour {

    public Animator anim;

    public void Open()
    {
        anim.SetTrigger("open");
    }

    public void Close()
    {
        anim.SetTrigger("close");
    }

}
