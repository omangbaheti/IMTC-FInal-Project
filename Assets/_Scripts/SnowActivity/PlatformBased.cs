using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBased : MonoBehaviour
{
    public float variableSpeed = -0.4f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, variableSpeed * Time.deltaTime);
    }
}
