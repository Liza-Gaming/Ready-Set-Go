using UnityEngine;

/**
 * Code from the course
 * This component moves its object in a fixed velocity.
 */
public class Mover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;
    [SerializeField] private float lifetime = 8f;

    public Transform PlayerPos;


    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        this.velocity = newVelocity;
    }

    private void FixedUpdate()
    {
        this.transform.position = SetZ(this.transform.position, PlayerPos.position.z);
    }

    Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    }

}