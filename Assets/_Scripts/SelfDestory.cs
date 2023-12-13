using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    [SerializeField] int countDown;
    void Start()
    {
        Destroy(gameObject, countDown);
    }


}
