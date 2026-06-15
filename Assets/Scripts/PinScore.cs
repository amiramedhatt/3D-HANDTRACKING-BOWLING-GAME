using UnityEngine;

public class PinScore : MonoBehaviour
{
    public GameManager gameManager;
    AudioSource audioSource;
    private bool hasBeenScored = false;
    private bool canCheck = false;
    private Vector3 initialUp;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialUp = transform.up;
        Invoke("EnableCheck", 2f);
    }

    public void ResetPin()
    {
        hasBeenScored = false;
        canCheck = false;
        gameObject.tag = "pin";
        initialUp = transform.up;
        Invoke("EnableCheck", 2f);
    }

    void EnableCheck()
    {
        canCheck = true;
    }

    void Update()
    {
        if (!hasBeenScored && canCheck)
        {
            float tiltAngle = Vector3.Angle(transform.up, initialUp);
            if (tiltAngle > 45f)
            {
                hasBeenScored = true;
                audioSource.Play();
                gameManager.PinKnocked();
                gameObject.tag = "Untagged";
                Invoke("DisablePin", audioSource.clip.length + 0.1f);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && !hasBeenScored)
        {
            if (collision.relativeVelocity.magnitude > 2f)
            {
                hasBeenScored = true;
                audioSource.Play();
                gameManager.PinKnocked();
                gameObject.tag = "Untagged";
                Invoke("DisablePin", audioSource.clip.length + 0.1f);
            }
        }
    }

    void DisablePin()
    {
        gameObject.SetActive(false);
    }
}