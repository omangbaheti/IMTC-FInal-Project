using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class FishingRod : MonoBehaviour, IActivity
{
    [SerializeField] private float offset = 10f;
    [SerializeField] private Vector3 anchoredPosition;

    private void Awake()
    {
        
    }
    

    private void OnEnable()
    {
        FishingActivity.OnFishingStarted.AddListener(ThrowBait);
    }
    
    private void OnDisable()
    {
        FishingActivity.OnFishingStarted.RemoveListener(ThrowBait);
    }

    private void ThrowBait()
    {
        
    }

    

    public void OnEnableActivity()
    {
        Debug.Log("Activity Enabled");
        gameObject.SetActive(true);
        transform.DOMoveY( anchoredPosition.y, .5f).SetEase(Ease.OutCubic);
    }
    
    public void OnDisableActivity()
    {
        Debug.Log("Activity Disabled");
        transform.DOMoveY(anchoredPosition.y-offset, .5f).
            OnComplete((()=> gameObject.SetActive(false) ));
    }
    
}
