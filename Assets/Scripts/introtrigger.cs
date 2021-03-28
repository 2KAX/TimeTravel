using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introtrigger : WhenGrabbed
{

    private static bool isFirst = true;

    public managedissolve dis;


    public override void Grab()
    {
        if (isFirst)
        {
            isFirst = false;
            managedissolve.isfirsttouch = true;
            dis.createeffect();
        }
    }
    public override void Released()
    {

    }
}
