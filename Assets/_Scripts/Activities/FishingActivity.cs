using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishingActivity : ActivityTrigger
{
    public static UnityEvent OnThrowBait = new UnityEvent();
    
    private bool isFishingStarted;
    private void Update()
    {
        
    }
}
