using UnityEngine;

public class GripDetection : MonoBehaviour
{
    public GameObject[] handPoints; // same array as HandTrackingControl
    public float gripThreshold = 0.5f;
    public bool isGripping = false;

    void Update()
    {
        if (handPoints == null || handPoints.Length < 21) return;

        Vector3 palm = handPoints[0].transform.localPosition;
        Vector3 index = handPoints[8].transform.localPosition;
        Vector3 middle = handPoints[12].transform.localPosition;
        Vector3 ring = handPoints[16].transform.localPosition;
        Vector3 pinky = handPoints[20].transform.localPosition;

        bool allCurled =
            Vector3.Distance(palm, index) < gripThreshold &&
            Vector3.Distance(palm, middle) < gripThreshold &&
            Vector3.Distance(palm, ring) < gripThreshold &&
            Vector3.Distance(palm, pinky) < gripThreshold;

        isGripping = allCurled;
    }
}