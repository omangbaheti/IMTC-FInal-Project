using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingCanvas : MonoBehaviour, IActivity
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnableActivity()
    {
        gameObject.SetActive(true);
    }

    public void OnDisableActivity()
    {
        gameObject.SetActive(false);
    }
}
