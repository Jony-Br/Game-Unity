//using UnityEngine;

//public class CalculateLerp
//{
//    public static Vector3 CalcLerp(float t, Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3)
//    {
//        Vector3 seekedPoint =
//            -P0 * Mathf.Pow(t, 3) + 3 * P0 * Mathf.Pow(t, 2) - 3 * P0 * t + P0 +
//            3 * P1 * Mathf.Pow(t, 3) - 6 * P1 * Mathf.Pow(t, 2) + 3 * P1 * t +
//            -3 * P2 * Mathf.Pow(t, 3) + 3 * P2 * Mathf.Pow(t, 2) +
//            P3 * Mathf.Pow(t, 3);
//        return seekedPoint;
//    }
//}  для 4 точок
using UnityEngine;

public class CalculateLerp
{
    public static Vector3 CalcLerp(float t, Vector3 P0, Vector3 P1, Vector3 P2)
    {
        Vector3 seekedPoint =
            (1 - 2*t + t*t) * P0 +
            (t - t * t) * 2 * P1 +
            t * t * P2;
        return seekedPoint;
    }
}// для 3 точок

