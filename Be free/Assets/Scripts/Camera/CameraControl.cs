using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform P0;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Vector3 tempPoint;
    [SerializeField] private Transform lookPoint; 
    [Range(0f,1f),SerializeField] private float t = 0.5f;
    [SerializeField] private Vector3[] cameraLocs;
    private bool camCheckpoint = false;
    private bool swiping = false;
    private bool transferingToNewPoint = false;
    private int iter = 1;
    private void Start()
    {
        transform.LookAt(lookPoint);
    }
    private void Update()
    {
        if (transferingToNewPoint)
        {
            t += 0.6f * Time.deltaTime;
            transform.position = CalculateLerp.CalcLerp(t, tempPoint, P0.position);
            if (t >= 1f) {
                transferingToNewPoint = false;
                t = 0f;
            }
            transform.LookAt(lookPoint);
        }
        else if (!swiping && Input.GetKey("d"))
        {
            swiping = true;
        }
        else if (swiping)
        {
            t += 0.6f * Time.deltaTime;

            if (camCheckpoint && /*isCamWithinReachToPoint(P1.position)*/t > 0.475f && t < 0.525f)
            {
                swiping = false;
            }
            if (t >= 1)
            {
                camCheckpoint = true;
                transferingToNewPoint = true;
                tempPoint = P2.position;

                iter += 3;
                P0.position = cameraLocs[iter - 1];
                P1.position = cameraLocs[iter];
                P2.position = cameraLocs[iter + 1];
                t = 0f;
                //t -= 1f;
            }
            if (!transferingToNewPoint)
            {
                transform.position = CalculateLerp.CalcLerp(Mathf.Clamp01(t),
                 P0.position, P1.position, P2.position);
                transform.LookAt(lookPoint);
            }
        }
    }
    //private bool isCamWithinReachToPoint(Vector3 pointPos) {
    //    return (pointPos - transform.position).magnitude > 0.25f;
    //}
}
