using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTrigger : WhenGrabbed
{
    bool first = true;
    [SerializeField] Appear appear;

    public override void Grab()
    {
        if (first)
        {
            first = false;
            appear.StartAppearing();
        }
    }
    public override void Released() {}
}
