using UnityEngine;

public class LineController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    LineRenderer lineRenderer;
    public Transform origin;
    public Transform destination;
    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>();
        lineRenderer.startWidth= 0.1f;
        lineRenderer.startWidth=0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0,origin.position);
        lineRenderer.SetPosition(1,destination.position);
    }
}
