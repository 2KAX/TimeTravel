using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WhenGrabbed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    abstract public void Grab();

    abstract public void Released();
    // Update is called once per frame
    void Update()
    {
        
    }
}
