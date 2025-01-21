using UnityEngine;
using UnityEngine.InputSystem;

public class BasketMover : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Movement speed of the basket")]
    private float _speed = 5f;

    [SerializeField]
    [Tooltip("Left and right bounds for the basket movement")]
    private float minX = -10f;
    [SerializeField]
    private float maxX = 10f;

    private float basketWidth;

    public InputAction PlayerControls;

    Vector2 moveDir = Vector2.zero; // Direction of the player by vector

    void OnEnable()
    {
        PlayerControls.Enable();
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }

    void Start()
    {
        // Calculate half the width of the basket in world space
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            basketWidth = renderer.bounds.extents.x;
        }
    }

    void Update()
    {

        moveDir = PlayerControls.ReadValue<Vector2>();

        // Calculate new position based on input
        float deltaX = moveDir.x * _speed * Time.deltaTime;
        float newX = transform.position.x + deltaX;

        // Clamp the new position within bounds
        newX = Mathf.Clamp(newX, minX + basketWidth, maxX - basketWidth);

        // Update the basket's position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
