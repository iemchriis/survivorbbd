using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offSet;

    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;

    private Vector3 currentVelocity = Vector3.zero;


    private void Awake()
    {
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = target.position + offSet;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothTime);
    }
}
