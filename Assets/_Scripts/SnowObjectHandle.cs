using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowObjectHandle : MonoBehaviour
{
    [SerializeField] private GameObject slicedSnow;
    [SerializeField] int pointsForThisItems;
    [HideInInspector] public WinterPlayerPoints winterPlayerPoints;

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
            winterPlayerPoints.UpdatePoints(pointsForThisItems);
        }
    }

    
}
