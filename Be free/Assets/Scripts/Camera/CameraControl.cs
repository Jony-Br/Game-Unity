using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform P0;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform P3;
    [SerializeField] private Transform lookPoint;
    [Range(0f, 1f), SerializeField] private float t = 0.5f;
    [SerializeField] private Vector3[] cameraLocs;

    private bool swiping = false;
    private int iter = 6;

    private void Start()
    {

        FindTangent();

        t = 1f;
        transform.position = CalculateLerp.CalcLerp(Mathf.Clamp01(t), P0.position, P1.position, P2.position, P3.position);
        transform.LookAt(lookPoint);
    }
    void FindTangent() {
        
    }
    private void Update()
    {

        if (!swiping && Input.GetKey("d"))
        {
            swiping = true;
        }
        else if (swiping) {
            t += 0.5f * Time.deltaTime;
            if (t >= 1f)
            {
                swiping = false;
                P0.position = cameraLocs[iter - 3];
                P1.position = cameraLocs[iter - 2];
                P2.position = cameraLocs[iter - 1];
                if (iter == cameraLocs.Length)
                {
                    iter = 0;
                    P3.position = cameraLocs[0];
                }
                else
                    P3.position = cameraLocs[iter];
                t = 0f;
                iter += 3;
                Debug.Log(iter);
                
            }

            transform.position = CalculateLerp.CalcLerp(Mathf.SmoothStep(0f, 1f, t)/*Vector3.SmoothDamp(P0.position,P3.position,*/
               /*Mathf.MoveTowards(t, 1f,Time.deltaTime)*/,/*Mathf.Clamp01(t)*/P0.position, P1.position, P2.position, P3.position) ;
            transform.LookAt(lookPoint);
        }


        //if (!swiping && Input.GetKey("d"))
        //{
        //    swiping = true;
        //    camCheckpoint = false;
        //    transferingToNewPoint = false;
        //}
        //else if (swiping)
        //{
        //    t += 0.5f * Time.deltaTime;

        //    if (camCheckpoint)
        //    {
        //        swiping = false;
        //        //transferingToNewPoint = false;
        //    }
        //    if (t >= 1f)
        //    {
        //        camCheckpoint = true;
        //        transferingToNewPoint = true;
        //        tempPoint = P2.position;

        //        iter += 3;
        //        P0.position = cameraLocs[iter - 1];
        //        P1.position = cameraLocs[iter];
        //        P2.position = cameraLocs[iter + 1];
        //        t = 0f;
        //        //t -= 1f;
        //    }
        //    if (!transferingToNewPoint)
        //    {
        //        transform.position = CalculateLerp.CalcLerp(Mathf.Clamp01(t),
        //         P0.position, P1.position, P2.position);
        //        transform.LookAt(lookPoint);
        //    }
        //}
    }
    //private bool isCamWithinReachToPoint(Vector3 pointPos) {
    //    return (pointPos - transform.position).magnitude > 0.25f;
    //}
}
