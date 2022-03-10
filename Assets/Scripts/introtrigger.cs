using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introtrigger : WhenGrabbed
{

    private static bool isFirst = true;

    public Spawn spawn;


    public override void Grab()
    {
        if (isFirst)
        {
            isFirst = false;
            spawn.Begin();
        }
    }
    public override void Released()
    {

    }
}
