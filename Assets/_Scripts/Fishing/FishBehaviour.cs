using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{

    [SerializeField] private float fishSpeed;
    private Rigidbody rigidbody;
    private bool changeDirection = false;
    public GameObject bait;
    private string status;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * fishSpeed;
    }

    private void Update()
    {
        if(bait == null) return;
        if (status == "GET_CAUGHT")
        {
            Vector3 followBaitVector = bait.transform.position - transform.position;
            transform.forward = followBaitVector;
            rigidbody.velocity = followBaitVector * (fishSpeed * 10f);
        }
        else if(status == "CAUGHT")
        {
            transform.position = bait.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FishBoundry"))
        {
            Movement();
        }
        else if (other.gameObject.CompareTag("FishBait"))
        {
            status = "CAUGHT";
        }
    }


    private void Movement()
    {
        transform.Rotate(0, 180, 0);
        rigidbody.velocity = transform.forward * fishSpeed;
        changeDirection = false;
    }

    public void GetBaited()
    {
        status = "GET_CAUGHT";
        Debug.Log("GetCaughtActivated");
    }
}
