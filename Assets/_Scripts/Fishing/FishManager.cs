using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishManager : MonoBehaviour, IActivity
{
    private FishBehaviour[] fishes;
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

    private void SetFishBehavior()
    {
        int randomFishIndex = Random.Range(0, fishes.Length);
        fishes[randomFishIndex].GetBaited();
    }
}
