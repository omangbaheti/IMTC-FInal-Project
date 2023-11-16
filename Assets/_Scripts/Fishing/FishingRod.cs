using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class FishingRod : MonoBehaviour, IActivity
{
    [SerializeField] private Vector3 offset = new Vector3(0,10,0);
    public void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public void OnEnableActivity()
    {
        gameObject.SetActive(true);
        transform.DOLocalMove(transform.position + offset, .5f).SetEase(Ease.OutCubic);
    }
    
    public void OnDisableActivity()
    {
        transform.DOLocalMove(transform.position - offset, .5f);
        gameObject.SetActive(false);
    }
}
