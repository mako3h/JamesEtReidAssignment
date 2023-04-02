using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAround : MonoBehaviour
{
    public float rotSpeed = 10.0f;
    public Vector3 midPoint = Vector3.zero;

    void Update()
    {
        //this makes the sphere rotate around, i added the mid point in there, and you can set the xyz, in the inspector, that the sphere will rotate around
        transform.RotateAround(midPoint, Vector3.up, rotSpeed * Time.deltaTime);

    }
}
