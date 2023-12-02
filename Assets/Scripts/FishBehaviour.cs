using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{

    Rigidbody rigidbody;
    [SerializeField] float fishSpeed;
    bool changeDirection = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * fishSpeed;
        //StartCoroutine(FishMovement());
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "FishBoundry")
        {
            Movement();
            //changeDirection = true;
        }
    }

    //public IEnumerator FishMovement()
    //{
    //    while (true)
    //    {
    //        rigidbody.velocity = transform.forward * fishSpeed;
    //        if (!changeDirection)
    //        {

    //        }
    //        else
    //        {
    //            Movement();
    //        }

    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}


    private void Movement()
    {
        //float rotateAngle = Random.Range(-270, 150);
        transform.Rotate(0, 180, 0);
        rigidbody.velocity = transform.forward * fishSpeed;
        changeDirection = false;
    }
}
