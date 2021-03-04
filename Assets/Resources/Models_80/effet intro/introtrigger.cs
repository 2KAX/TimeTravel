using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introtrigger : WhenGrabbed
{

    private static bool isFirst = true;

    public managedissolve dis;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

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
