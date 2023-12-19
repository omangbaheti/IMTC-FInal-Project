using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class XRInputManager : Singleton<XRInputManager>
{
    public Transform leftController;
    public Transform rightController;

    public InputActionReference APress;
    public InputActionReference BPress;
    
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
