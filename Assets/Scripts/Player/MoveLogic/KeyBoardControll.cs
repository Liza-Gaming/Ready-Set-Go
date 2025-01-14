using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class KeyBoardControll : MonoBehaviour
{
    [SerializeField] float speed = 6.0f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] float rotationSpeed = 360f; // Degrees per second for smooth rotation
    public CameraBob cameraBob;

    float velocityY;
    bool isGrounded;

    CharacterController controller;
    Vector3 velocity;

    private Quaternion targetRotation; // Target rotation
    private bool isRotating = false;   // Whether the character is currently rotating

    void Start()
    {
        controller = GetComponent<CharacterController>();

        targetRotation = transform.rotation; // Initialize target rotation
    }

    void Update()
    {
        UpdateMove();
        SmoothRotation(); // Handle smooth rotation
    }

    void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        if (isGrounded && velocityY < 0)
        {
            velocityY = 0f;
        }

        // Vertical movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity = transform.forward * speed;
            cameraBob.SetBobbing(true);
        }
        else
        {
            velocity = Vector3.zero;
            cameraBob.SetBobbing(false);
        }

        // Rotational movement
        if (!isRotating) // Allow new rotation only if not already rotating
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartRotation(-90f);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartRotation(90f);
            }
        }

        // Apply gravity
        velocityY += gravity * Time.deltaTime;

        // Combine vertical and gravity components
        velocity += Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

    void StartRotation(float angle)
    {
        targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0); // Set the target rotation
        isRotating = true; // Start rotating
    }

    void SmoothRotation()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f) // Check if rotation is nearly complete
            {
                transform.rotation = targetRotation; // Snap to the exact target rotation
                isRotating = false; // Stop rotating
            }
        }
    }
}
