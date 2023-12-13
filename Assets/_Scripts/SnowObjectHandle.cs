using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowObjectHandle : MonoBehaviour
{
    [SerializeField] private GameObject slicedSnow;
    void TriggerSlicedAnimation()
    {
        GameObject slicedFoodTemp = Instantiate(slicedSnow, transform.position, slicedSnow.transform.rotation);
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TriggerSlicedAnimation();
        }
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
