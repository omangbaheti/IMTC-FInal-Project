using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandle : MonoBehaviour
{
    [SerializeField] private GameObject slicedFood;
    [SerializeField] FoodPlayerPoints playerPoints;
    [SerializeField] int pointsForThisItem;
    void TriggerSlicedAnimation()
    {
        Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject slicedFoodTemp = Instantiate(slicedFood, spawnPosition, transform.rotation);
        Destroy(gameObject);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerSlicedAnimation();
            playerPoints.UpdatePoints(pointsForThisItem);
        }
    }

    //testing
    //private void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        TriggerSlicedAnimation();
    //    }
    //}
}
