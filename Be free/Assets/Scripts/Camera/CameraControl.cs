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
    [Range(0f, 1f), SerializeField] private float t = 0.5f;
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
      
        if (!swiping && Input.GetKey("d"))
        {
            Debug.Log("Error!!!");
            swiping = true;

            camCheckpoint = false;
            transferingToNewPoint = false;
        }
        else if (swiping)
        {
            t += 0.5f * Time.deltaTime;

            if (camCheckpoint)
            {
                swiping = false;
                //transferingToNewPoint = false;
            }
            if (t >= 1f)
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
