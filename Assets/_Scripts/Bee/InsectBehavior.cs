using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody bugRB;
    private bool changeDirection = false;


    // Start is called before the first frame update
    void Start()
    {
        bugRB = GetComponent<Rigidbody>();
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Movement()
    {
        transform.Rotate(0, 180, 0);
        bugRB.velocity = transform.forward * speed;
        changeDirection = false;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BugBoundary"))
        {
            Movement();
        }
        else if(other.gameObject.CompareTag("BugNet"))
        {
            Destroy(gameObject);
        }
    }
}
