using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private Transform P0;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform P3;
    [SerializeField] private Transform lookPoint; 
    [Range(0f,1f),SerializeField] private float t;

    private void Update()
    {
        
        cam.transform.position = CalculateLerp.CalcLerp(Mathf.Clamp01(t),
             P0.position, P1.position, P2.position, P3.position);

        cam.transform.LookAt(lookPoint);
    }
}
