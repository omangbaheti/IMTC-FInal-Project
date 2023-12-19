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
        inputManager = XRInputManager.Instance;
        inputManager.aPressed.AddListener(Fishing);
    }

    private void OnDisable()
    {
        inputManager.aPressed.RemoveListener(Fishing);
    }

    private void Fishing()
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
