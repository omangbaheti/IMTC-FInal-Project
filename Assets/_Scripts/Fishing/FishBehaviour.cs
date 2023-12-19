using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{

    [SerializeField] private float fishSpeed;
    private Rigidbody rigidbody;
    private bool changeDirection = false;
    private GameObject bait;
    private string status;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * fishSpeed;
    }

    private void Update()
    {
        if (status == "GET_CAUGHT")
        {
            transform.forward = bait.transform.position;
            rigidbody.velocity = transform.forward * fishSpeed;
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
    }
}
