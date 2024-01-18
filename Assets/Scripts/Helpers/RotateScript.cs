using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    void Update()
    {
        // Rotate the object around its up axis (Y-axis)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
