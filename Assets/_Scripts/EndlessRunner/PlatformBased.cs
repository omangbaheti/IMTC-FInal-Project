using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBased : MonoBehaviour
{
    public float variableSpeed = -0.4f;

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0, 0, variableSpeed * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * variableSpeed;
    }
}
