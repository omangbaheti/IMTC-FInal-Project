using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowActivity : ActivityTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
