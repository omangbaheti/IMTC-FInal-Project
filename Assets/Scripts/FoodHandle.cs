using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandle : MonoBehaviour
{
    [SerializeField] private GameObject slicedFood;
    void TriggerSlicedAnimation()
    {
        GameObject slicedFoodTemp = Instantiate(slicedFood, transform.position, transform.rotation);
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
