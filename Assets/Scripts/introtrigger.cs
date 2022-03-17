using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introtrigger : WhenGrabbed
{

    bool first = true;
    public Appear appear;

    public override void Grab()
    {
        if (first)
        {
            first = false;
            appear.Spawn();
        }
    }
    public override void Released()
    {

    }
}
