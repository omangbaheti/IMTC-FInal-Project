using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR;


public class FishingRod : MonoBehaviour, IActivity
{
    [SerializeField] private float offset = 10f;
    [SerializeField] private Vector3 anchoredPosition;
    [SerializeField] private GameObject bait;
    [SerializeField] private GameObject tip;
    private LineRenderer rope;
    private XRInputData _inputData;
    private void Awake()
    {
        bait = transform.GetChild(0).gameObject;
        rope = GetComponent<LineRenderer>();
        rope.positionCount = 2;
    }

    private void Update()
    { 
        _inputData._rightController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 devicePosition); 
        _inputData._rightController.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion deviceRotation);
        transform.rotation = deviceRotation;
        transform.position = devicePosition;
        rope.SetPosition(0, tip.transform.position);
        rope.SetPosition(1, bait.transform.position);
        
    }

    private void OnEnable()
    {
        FishingActivity.OnThrowBait.AddListener(ThrowBait);
    }
    
    private void OnDisable()
    {
        FishingActivity.OnThrowBait.RemoveListener(ThrowBait);
    }

    private void ThrowBait()
    {
        
    }

    

    public void OnEnableActivity()
    {
        Debug.Log("Activity Enabled");
        gameObject.SetActive(true);
        
    }
    
    public void OnDisableActivity()
    {
        Debug.Log("Activity Disabled");
        gameObject.SetActive(false);
    }
    
}
