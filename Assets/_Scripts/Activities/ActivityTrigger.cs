using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class  ActivityTrigger : MonoBehaviour
{
    [SerializeField] private string activityTag;
    [SerializeField] protected GameObject[] activityObjects;

    [SerializeField] protected UnityEvent onEnableActivity = new UnityEvent();
    [SerializeField] protected UnityEvent onDisableActivity = new UnityEvent();
    
    private void Awake()
    {
        activityObjects = GameObject.FindGameObjectsWithTag(activityTag);
        ActivateObjects();
        onDisableActivity?.Invoke();
    }


    private void OnDestroy()
    {
        DeactivateObjects();
    }
    

    private void OnTriggerEnter(Collider activityTrigger)
    {
        Debug.Log("Enter");
        if (activityTrigger.gameObject.CompareTag("MainCamera"))
        {
            onEnableActivity?.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider activityTrigger)
    {
        Debug.Log("Exit");
        if (activityTrigger.gameObject.CompareTag("MainCamera"))
        {
            onDisableActivity?.Invoke();
        }
    }

    protected virtual void ActivateObjects()
    {
        foreach (GameObject activityGO in activityObjects)
        {
            activityGO.SetActive(true);
            IActivity activity = activityGO.GetComponent(typeof(IActivity)) as IActivity;
            if (activity == null) continue;
            onEnableActivity.AddListener(activity.OnEnableActivity);
            onDisableActivity.AddListener(activity.OnDisableActivity);
        }
    }
    
    protected virtual void DeactivateObjects()
    {
        onEnableActivity.RemoveAllListeners();
        onDisableActivity.RemoveAllListeners();
    }
}
