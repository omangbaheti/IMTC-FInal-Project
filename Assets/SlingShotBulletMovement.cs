using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotBulletMovement : MonoBehaviour
{
    public float speed = 10f;           // Bullet speed
    public float gravity = 9.8f;        // Gravity strength
    

    [SerializeField] private GameObject ballPrefab;


    //testing
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
        ball.transform.parent = transform;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
