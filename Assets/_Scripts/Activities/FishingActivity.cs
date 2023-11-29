using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishingActivity : ActivityManager
{
    public static UnityEvent OnThrowBait = new UnityEvent();
    
    private bool isFishingStarted;
    private void Update()
    {
        if (!isFishingStarted)
        {
            if (Input.touchCount > 0)
            {
                OnThrowBait?.Invoke();
            }
        }
    }
}
