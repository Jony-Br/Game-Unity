using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform P0;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform lookPoint; 
    [Range(0f,1f),SerializeField] private float t;
    [SerializeField] private Vector3[] cameraLocs;
    private void Start()
    {
        transform.LookAt(lookPoint);
    }
    private void Update()
    {
        if (Input.GetKey("d"))
        {
            //P0 = 
            transform.position = CalculateLerp.CalcLerp(Mathf.Clamp01(t),
                 P0.position, P1.position, P2.position);

            transform.LookAt(lookPoint);
        }
    }
}
