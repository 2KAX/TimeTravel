using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRInputLoader : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset actions;

    public InputActionMap rightHandActions { get; private set; }
    public InputActionMap leftHandActions { get; private set; }


    private void OnEnable()
    {
        if (actions != null)
        {
            actions.Enable();
            rightHandActions = actions.FindActionMap("XRI RightHand");
            leftHandActions = actions.FindActionMap("XRI LeftHand");
        }
    }

    private void OnDisable()
    {
        if (actions != null)
            actions.Disable();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
