using UnityEngine;

public class HandTrackingControl : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject[] handPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive.data;
        if (string.IsNullOrEmpty(data))
        {
            return;
        }
        if (data.Length<2)
        {
            return;
        }
        data=data.Remove(0,1);
        data = data.Remove(data.Length-1,1); 
        string [] points = data.Split(',');
        for (int i=0;i<21;i++)
        {
            float x = float.Parse(points[i*3])/50;
            float y = float.Parse(points[i*3+1])/50;
            float z = float.Parse(points[i*3+2])/50;
            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }
}
