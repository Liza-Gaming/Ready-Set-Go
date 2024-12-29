using UnityEngine;

public class BasketMover : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Movement speed in meters per second")]
    private float _speed = 5f;

    [SerializeField]
    [Tooltip("Distance to move per button press")]
    private float moveDistance = 1f; // Set this to how far you want it to move per press

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // The actual movement is triggered by button presses directly
    }

    // Public methods to be called by UI buttons
    public void MoveLeft()
    {
        // Move left by a fixed distance
        rb.MovePosition(rb.position + Vector3.left * moveDistance);
    }

    public void MoveRight()
    {
        // Move right by a fixed distance
        rb.MovePosition(rb.position + Vector3.right * moveDistance);
    }
}
