using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    public float followSpeed = 5f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isFollowing = false;
    private float ballStartX;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void StartFollowing()
    {
        isFollowing = true;
        ballStartX = ball.transform.position.x;
    }

    public void StopFollowing()
    {
        isFollowing = false;
        StartCoroutine(ReturnToOriginal());
    }

    void Update()
{
    if (isFollowing)
    {
        float xDelta = ball.transform.position.x - ballStartX;
        Vector3 targetPos = new Vector3(originalPosition.x + xDelta, originalPosition.y, originalPosition.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}

    IEnumerator ReturnToOriginal()
    {
        yield return new WaitForSeconds(2f);
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * followSpeed;
            transform.position = Vector3.Lerp(transform.position, originalPosition, t);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, t);
            yield return null;
        }
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}