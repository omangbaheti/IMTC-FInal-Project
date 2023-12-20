using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiRods : MonoBehaviour, IActivity
{
    [SerializeField] private GameObject leftRod;
    [SerializeField] private GameObject rightRod;
    private Vector3 devicePosition;
    private Quaternion deviceRotation;
    private XRInputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = XRInputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        leftRod.transform.position = inputManager.leftControllerTransform.position;
        leftRod.transform.rotation = inputManager.leftControllerTransform.rotation;
        rightRod.transform.position = inputManager.rightControllerTransform.position;
        rightRod.transform.rotation = inputManager.rightControllerTransform.rotation;
    }
}
