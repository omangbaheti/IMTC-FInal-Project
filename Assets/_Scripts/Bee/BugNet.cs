using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;


public class BugNet : MonoBehaviour, IActivity
{
    private Vector3 devicePosition;
    private Quaternion deviceRotation;
    private XRInputManager inputManager;

    private void Awake()
    {
        inputManager = XRInputManager.Instance;

    }


    private void Update()
    {
        transform.position = inputManager.rightControllerTransform.position;
        transform.rotation = inputManager.rightControllerTransform.rotation;
    }

    public void OnEnableActivity()
    {
        Debug.Log("Bug Activity Enabled");
        gameObject.SetActive(true);
    }
    
    public void OnDisableActivity()
    {
        Debug.Log("Bug Activity Disabled");
        gameObject.SetActive(false);
    }
    
}
