using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowActivity : ActivityTrigger
{
    void Start()
    {
        
    }
    
    protected override void DeactivateObjects()
    {
        base.DeactivateObjects();
        foreach (var activity in activityObjects)
        {
            activity.SetActive(false);
        }
    }
}
