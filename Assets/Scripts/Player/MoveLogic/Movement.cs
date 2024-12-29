using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float gravity = -30f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float rotationSpeed = 180f; // Adjust rotation speed as needed

    private CharacterController controller;
    private float velocityY;
    private bool isGrounded;
    private Quaternion targetRotation; // Target rotation
    private bool isRotating; // Flag to check if rotation is ongoing

    void Start()
    {
        controller = GetComponent<CharacterController>();
        targetRotation = transform.rotation; // Initialize with current rotation
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        if (isGrounded && velocityY < 0)
        {
            velocityY = 0f;
        }

        ApplyGravity();

        if (isRotating)
        {
            RotateSmoothly();
        }
    }

    public void MoveForward(bool isMoving)
    {
        if (isMoving)
        {
            Vector3 move = transform.forward * speed;
            controller.Move(move * Time.deltaTime);
        }
    }

    public void RotateLeft()
    {
        StartRotation(-90);
    }

    public void RotateRight()
    {
        StartRotation(90);
    }

    private void StartRotation(int angle)
    {
        targetRotation *= Quaternion.Euler(0, angle, 0); // Set the target rotation
        isRotating = true; // Start rotating
    }

    private void RotateSmoothly()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f) // Check if rotation is complete
        {
            transform.rotation = targetRotation; // Snap to target rotation
            isRotating = false; // Stop rotating
        }
    }

    private void ApplyGravity()
    {
        velocityY += gravity * Time.deltaTime;
        Vector3 gravityVector = Vector3.up * velocityY;
        controller.Move(gravityVector * Time.deltaTime);
    }

}
