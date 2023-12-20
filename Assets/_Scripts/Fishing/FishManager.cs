using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishManager : MonoBehaviour, IActivity
{
    [SerializeField] private FishBehaviour[] fishes;
    [SerializeField] private GameObject bait;
    void Start()
    {
        fishes = GetComponentsInChildren<FishBehaviour>();
    }
    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        FishingActivity.OnThrowBait.AddListener(SetFishBehavior);
    }

    private void OnDisable()
    {
        FishingActivity.OnThrowBait.AddListener(SetFishBehavior);
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("FishBait"))
        {
            foreach (FishBehaviour fish in fishes)
            {
                fish.bait = trigger.gameObject;
            }
        }
    }

    private void SetFishBehavior()
    {
        int randomFishIndex = Random.Range(0, fishes.Length);
        fishes[randomFishIndex].GetBaited();
    }
}
