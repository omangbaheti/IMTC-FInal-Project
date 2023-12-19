using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FishingActivity : ActivityTrigger
{
    public static UnityEvent OnThrowBait = new UnityEvent();
    public static UnityEvent OnReelIn = new UnityEvent();
    private bool isFishingStarted;

    private XRInputManager inputManager;
    
    private void OnEnable()
    {
        inputManager.APress.action.performed += Fishing;
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        inputManager = XRInputManager.Instance;
    }

    private void Fishing(InputAction.CallbackContext callbackContext)
    {
        isFishingStarted = !isFishingStarted;
        if (isFishingStarted)
        {
            OnThrowBait?.Invoke();
        }
        else
        {
            OnReelIn?.Invoke();
        }
    }

    private void Update()
    {
        
    }
}
