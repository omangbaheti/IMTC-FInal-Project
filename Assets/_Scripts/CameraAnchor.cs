using System.Collections;
using System.Collections.Generic;
using MixedReality.Toolkit;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    private Transform mainCam;
    [SerializeField] private Vector3 offset = new(0, 0, 10);
    [SerializeField] private List<string> tags;

    private Dictionary<string, GameObject[]> activityObjects;
    void Start()
    {
        mainCam = Camera.main.transform;
    }

    void Update()
    {
        transform.position = mainCam.position + offset;
        transform.rotation = mainCam.rotation;
    }


    
}
