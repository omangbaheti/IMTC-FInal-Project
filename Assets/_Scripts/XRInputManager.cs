using System;
using UnityEngine;
using UnityEngine.Events;

public class XRInputManager : Singleton<XRInputManager>
{
    [SerializeField] private Transform leftControllerTransform;
    public OVRInput.Controller leftController;
    public UnityEvent indexTriggerPressedL;
    public UnityEvent indexTriggerAnalogL;
    public UnityEvent middleTriggerPressedL;
    public UnityEvent middleTriggerAnalogL;
    public UnityEvent<OVRInput.Axis2D> joystickL;
    public UnityEvent yPressed;
    public UnityEvent xPressed;
    
    [SerializeField] private Transform rightControllerTransform;
    public OVRInput.Controller rightController;
    public UnityEvent indexTriggerPressedR;
    public UnityEvent indexTriggerAnalogR;
    public UnityEvent middleTriggerPressedR;
    public UnityEvent middleTriggerAnalogR;
    public UnityEvent<OVRInput.Axis2D> joystickR;
    public UnityEvent aPressed;
    public UnityEvent bPressed;

    private void Update()
    {
        
        //RightControllerInputs
        if (OVRInput.GetDown(OVRInput.Button.One, rightController))
        {
            aPressed?.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two, rightController))
        {
            bPressed?.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, rightController))
        {
            indexTriggerPressedR?.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick, rightController))
        {
            middleTriggerPressedR?.Invoke();
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController) != default)
        {
            joystickR?.Invoke((OVRInput.Axis2D.PrimaryThumbstick));
        }
        
        //LeftControllerInputs
        
        if (OVRInput.GetDown(OVRInput.Button.One, leftController))
        {
            xPressed?.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two, leftController))
        {
            yPressed?.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, leftController))
        {
            indexTriggerPressedL?.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick, leftController))
        {
            middleTriggerPressedL?.Invoke();
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, leftController) != default)
        {
            joystickL?.Invoke((OVRInput.Axis2D.PrimaryThumbstick));
        }
        
    }
}
