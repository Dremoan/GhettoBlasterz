using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteBehaviour : MonoBehaviour {

    public Animator anim;

    private bool opened = false;

    public void Open()
    {
        if(!opened)anim.SetTrigger("open");
        opened = true;
    }

    public void Close()
    {
        anim.SetTrigger("close");
    }

}
