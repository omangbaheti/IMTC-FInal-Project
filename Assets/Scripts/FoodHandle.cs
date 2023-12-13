using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandle : MonoBehaviour
{
    [SerializeField] private GameObject slicedFood;
    void TriggerSlicedAnimation()
    {
        Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject slicedFoodTemp = Instantiate(slicedFood, spawnPosition, transform.rotation);
        Destroy(gameObject);

    }

    //testing
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TriggerSlicedAnimation();
        }
    }
}
