using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;
using Input = Niantic.Lightship.AR.Input;

public class SlingShot : MonoBehaviour, IActivity
{
    
    [SerializeField] private float offset = 10f;
    [SerializeField] private Vector3 anchoredPosition;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;

    private Rigidbody ballRigidbody;
    void Start()
    {
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            
        }
    }

    public void SpawnBall()
    {
        var ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity, transform);
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    public void LaunchBall()
    {
        
        ballRigidbody.AddForce();
    }

    public void OnEnableActivity()
    {
        Debug.Log("Activity Enabled");
        gameObject.SetActive(true);
        transform.DOMoveY( anchoredPosition.y, .5f).SetEase(Ease.OutCubic);
    }
    
    public void OnDisableActivity()
    {
        Debug.Log("Activity Disabled");
        transform.DOMoveY(anchoredPosition.y-offset, .5f).
            OnComplete((()=> gameObject.SetActive(false) ));
    }
}
