using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSmoothDamp : MonoBehaviour
{
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;
    [SerializeField] float smoothTime;
    [SerializeField] float maxSpeed;
    [SerializeField] Vector3 vel;
    [SerializeField] private float t;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, p2.position, ref vel, smoothTime, maxSpeed);
        //t = Mathf.SmoothDamp(t, 1f, ref vel, smoothTime, maxSpeed);
        Debug.Log(t);
    }
}
