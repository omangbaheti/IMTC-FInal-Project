using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsBehaviour : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float animalSpeeds;
    [SerializeField] float directionChangedInterval = 1.0f;
    private Vector3 targetVelocity;

    [SerializeField] Transform maxBoundaryBox;
    [SerializeField] Transform minBoundaryBox;
    Vector3 maxPosition;
    Vector3 minPosition;

    public enum AnimalsTypes
    {
        fly,
        ground
    }
    public AnimalsTypes thisAnimal = new AnimalsTypes();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        maxPosition = maxBoundaryBox.transform.position;
        minPosition = minBoundaryBox.transform.position;
        StartCoroutine(ChangeDirectionRoutine());
        ChangeDirection();
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(directionChangedInterval);
            ChangeDirection();
        }
    }

    //bool CheckwithinBoundary()
    //{
    //    Debug.Log("max" + new Vector3(maxPosition.x, maxPosition.y, maxPosition.z) + "min" + new Vector3(minPosition.x, minPosition.y, minPosition.z) + "this" + new Vector3(transform.position.x, transform.position.y, transform.position.z));
    //    if(transform.position.x < maxPosition.x && transform.position.y < maxPosition.y && transform.position.z < maxPosition.z)
    //    {
    //        if(transform.position.x > minPosition.x && transform.position.y > minPosition.y && transform.position.z > minPosition.z)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

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

    private void ChangeDirection()
    {
        Vector3 targetPosition;

        if (thisAnimal == AnimalsTypes.fly)
        {
            targetPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );
            targetVelocity = (targetPosition - transform.position).normalized * animalSpeeds;
        }
        else
        {
            targetPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, minPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
            );

            targetVelocity = (targetPosition - transform.position).normalized * animalSpeeds;
        }
        

        
    }

    //private void BeeMovement()
    //{
    //    int randomRotationX = Random.Range(-180, 180);
    //    int randomRotationY = Random.Range(-180, 180);
    //    //int randomRotationZ = Random.Range(-180, 180);
    //    transform.Rotate(randomRotationX, randomRotationY, 0);
    //    rigidbody.velocity = transform.right * animalSpeeds;
    //}

    //testing
    void FixedUpdate()
    {
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, targetVelocity, Time.fixedDeltaTime * animalSpeeds);

        if (targetVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetVelocity);
            rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * animalSpeeds));
        }
    }
}

