using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBased : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -4f * Time.deltaTime);
    }
}
