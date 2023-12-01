using System;
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
    [SerializeField] private float force = 10f;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;

    private Rigidbody ballRigidbody;
    private Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerUp += HandleBall;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerUp -= HandleBall;
    }
    

    private void HandleBall(LeanFinger leanFinger)
    {
        Debug.Log($"Hellow touch {leanFinger.ScreenPosition}");
        if (ballRigidbody == null)
        {
            SpawnBall();
        }
    }
    
    public void SpawnBall()
    {
        var ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity, transform);
        ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.useGravity = false;
        LaunchBall();
    }

    public void LaunchBall()
    {
        ballRigidbody.useGravity = true;
        ballRigidbody.AddForce(mainCam.transform.forward * force);
        StartCoroutine(DestroyBall());
    }

    public IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(4f);
        Destroy(ballRigidbody.gameObject);
    }

    public void OnEnableActivity()
    {
        Debug.Log("Activity Enabled");
        gameObject.SetActive(true);
        transform.DOLocalMoveY( anchoredPosition.y, .5f).SetEase(Ease.OutCubic);
    }
    
    public void OnDisableActivity()
    {
        Debug.Log("Activity Disabled");
        transform.DOLocalMoveY(anchoredPosition.y-offset, .5f).
            OnComplete((()=> gameObject.SetActive(false) ));
    }
}
