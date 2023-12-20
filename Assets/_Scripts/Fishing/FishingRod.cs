using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;


public class FishingRod : MonoBehaviour, IActivity
{
    [SerializeField] private GameObject fishingRod;
    [SerializeField] private GameObject bait;
    [SerializeField] private GameObject tip;
    [SerializeField] private Vector3 throwForce;
    private LineRenderer rope;
    private Vector3 devicePosition;
    private Quaternion deviceRotation;
    private XRInputManager inputManager;
    private Rigidbody baitRB;
    
    private void Awake()
    {
        baitRB = bait.GetComponent<Rigidbody>();
        baitRB.useGravity = false;
        baitRB.constraints = RigidbodyConstraints.FreezeAll;
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
        transform.position = inputManager.rightControllerTransform.position;
        fishingRod.transform.rotation = inputManager.rightControllerTransform.rotation;
        rope.SetPosition(0, tip.transform.position);
        rope.SetPosition(1, bait.transform.position);
    }
    
    private void ThrowBait()
    {
        baitRB.constraints = RigidbodyConstraints.None;
        baitRB.useGravity = true;
        baitRB.AddRelativeForce(throwForce, ForceMode.Impulse);
    }

    private void ReelIn()
    {
        baitRB.useGravity = false;
        baitRB.constraints = RigidbodyConstraints.FreezeAll;
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
