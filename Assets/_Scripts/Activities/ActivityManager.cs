using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActivityManager : MonoBehaviour
{
    [SerializeField] private string activityTag;
    [SerializeField] private GameObject[] activityObjects;

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

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider activityTrigger)
    {
        if (activityTrigger.gameObject.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera");
            onEnableActivity?.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider activityTrigger)
    {
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
            IActivity activity = (IActivity)activityGO.GetComponent(typeof(IActivity));
            onEnableActivity.AddListener(activity.OnEnableActivity);
            onDisableActivity.AddListener(activity.OnEnableActivity);
        }
    }
    
    protected virtual void DeactivateObjects()
    {
        onEnableActivity.RemoveAllListeners();
        onDisableActivity.RemoveAllListeners();
    }
}
