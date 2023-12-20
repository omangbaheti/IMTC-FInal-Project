using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

public class SlingShot : MonoBehaviour, IActivity
{
    
    [SerializeField] private float force = 10f;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;

    private Rigidbody ballRigidbody;
    private XRInputManager inputManager;
    void Awake()
    {
        
    }

    private void OnEnable()
    {
        inputManager = XRInputManager.Instance;
        inputManager.aPressed.AddListener(HandleBall);
    }

    private void OnDisable()
    {
        inputManager.aPressed.RemoveListener(HandleBall);
    }

    private void Update()
    {
        transform.position = inputManager.rightControllerTransform.position;
        transform.rotation = inputManager.rightControllerTransform.rotation;
    }


    private void HandleBall()
    {
        Debug.Log("A Pressed");
        if (ballRigidbody == null)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        var ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.useGravity = false;
        LaunchBall();
    }

    public void LaunchBall()
    {
        ballRigidbody.useGravity = true;
        ballRigidbody.AddForce(inputManager.rightControllerTransform.transform.forward * force);
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
    }
    
    public void OnDisableActivity()
    {
        Debug.Log("Activity Disabled");
        gameObject.SetActive(false);
    }
}
