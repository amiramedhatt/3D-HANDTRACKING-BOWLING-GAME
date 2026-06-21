using UnityEngine;

public class BallPickup : MonoBehaviour
{
    public GripDetection gripDetection;
    public GameObject palmPoint;
    public float pickupDistance = 5f;
    public GameManager gameManager;
    public CameraController cameraController;

    private Rigidbody rb;
    private bool isHeld = false;
    public bool ballThrown = false;
    private bool wasGripping = false;
    private Vector3 lastPalmPosition;
    private Vector3 throwVelocity;
    private float lockedZ;
    private bool canPickup = false;
    private float throwTimer= 0f;
    private float throwTimeLimit=7f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // freeze ball at start
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Invoke("EnablePickup", 3f); // wait 3 seconds before allowing pickup
    }
    void EnablePickup()
    {
        canPickup=true;
    }
    
    void Update()
{
    float distanceToBall = Vector3.Distance(palmPoint.transform.position, transform.position);

    if (canPickup && gripDetection.isGripping && distanceToBall < pickupDistance && !isHeld)
    {
        isHeld = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rb.isKinematic = true;
    }

    if (isHeld)
    {
        transform.position = palmPoint.transform.position;
        throwVelocity = (palmPoint.transform.position - lastPalmPosition) / Time.deltaTime;
    }

    if (wasGripping && !gripDetection.isGripping && isHeld)
    {
        throwTimer = 0f; // reset timer
        isHeld = false;
        rb.isKinematic = false;
        lockedZ = transform.position.z;
        float speed = Mathf.Max(Mathf.Abs(throwVelocity.x), 15f);
        rb.linearVelocity = new Vector3(speed + 10f, 0, 0);
        ballThrown = true;
        cameraController.StartFollowing();
    }

    if (ballThrown)
    {
        Vector3 pos = rb.position;
        rb.MovePosition(new Vector3(pos.x, pos.y, lockedZ));
        throwTimer += Time.deltaTime;
    if (throwTimer >= throwTimeLimit)
    {
        throwTimer = 0f;
        ballThrown = false;
        cameraController.StopFollowing();
        gameManager.BallStopped();
    }
    }

    wasGripping = gripDetection.isGripping;
    lastPalmPosition = palmPoint.transform.position;
}
}