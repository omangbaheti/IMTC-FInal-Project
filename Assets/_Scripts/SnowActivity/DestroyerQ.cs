using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerQ : MonoBehaviour
{
    public WinterPlayerPoints winterPlayerPoints;
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("SnowActivity"))
        {
            winterPlayerPoints.UpdatePoints(1);
            Destroy(trigger.gameObject); 
        }
        
    }
}
