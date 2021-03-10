using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TurnCamera : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public float turnSensitivity = 10.0f;

    private Transform parent;
    private bool hasTurned = false;


    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.SnapTurnLeft.GetStateDown(handType)&& !hasTurned)
        {
            parent.rotation *= Quaternion.AngleAxis(turnSensitivity, Vector3.up);
            hasTurned = true;
        }
        else if (SteamVR_Actions._default.SnapTurnRight.GetStateDown(handType) && !hasTurned)
        {
            parent.rotation *= Quaternion.AngleAxis(-turnSensitivity, Vector3.up);
            hasTurned = true;
        }
        if (SteamVR_Actions._default.SnapTurnLeft.GetStateUp(handType))
        {
            hasTurned = false;
        }
        else if (SteamVR_Actions._default.SnapTurnRight.GetStateUp(handType))
        {
            hasTurned = false;
        }
    }
}
