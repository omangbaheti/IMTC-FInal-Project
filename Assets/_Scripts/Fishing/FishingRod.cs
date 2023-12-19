using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;


public class FishingRod : MonoBehaviour, IActivity
{
    [SerializeField] private GameObject bait;
    [SerializeField] private Vector3 throwForce;
    [SerializeField] private GameObject tip;
    private LineRenderer rope;
    private Vector3 devicePosition;
    private Quaternion deviceRotation;
    private XRInputManager inputManager;

    private Rigidbody baitRB;
    
    private void Awake()
    {
        bait = transform.GetChild(0).gameObject;
        baitRB = bait.GetComponent<Rigidbody>();
        baitRB.useGravity = false;
        rope = GetComponent<LineRenderer>();
        rope.positionCount = 2;
        inputManager = XRInputManager.Instance;

    }
    private void OnEnable()
    {
        FishingActivity.OnThrowBait.AddListener(ThrowBait);
        FishingActivity.OnReelIn.AddListener(ReelIn);
    }
    
    private void OnDisable()
    {
        FishingActivity.OnThrowBait.RemoveListener(ThrowBait);
        FishingActivity.OnReelIn.RemoveListener(ReelIn);
    }
    
    

    private void Update()
    { 
        rope.SetPosition(0, tip.transform.position);
        rope.SetPosition(1, bait.transform.position);
        
    }
    
    private void ThrowBait()
    {
        baitRB.useGravity = true;
        baitRB.AddForce(throwForce, ForceMode.Impulse);
    }

    private void ReelIn()
    {
        baitRB.useGravity = false;
        baitRB.transform.DOMove(tip.transform.position, 1f);
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
