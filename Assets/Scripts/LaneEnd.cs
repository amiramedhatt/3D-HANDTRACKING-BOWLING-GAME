using UnityEngine;

public class LaneEnd : MonoBehaviour
{
    public GameManager gameManager;
    public CameraController cameraController;
    public BallPickup ballPickup;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball") && !hasTriggered)
        {
            hasTriggered = true;
            ballPickup.ballThrown = false;
            cameraController.StopFollowing();
            Invoke("EndAttempt", 2f);
        }
    }

    void EndAttempt()
    {
        hasTriggered = false;
        gameManager.BallStopped();
    }
}