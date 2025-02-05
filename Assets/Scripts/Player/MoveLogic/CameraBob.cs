using UnityEngine;

/**
 * Responsible for the walking effect
 */
public class CameraBob : MonoBehaviour
{
    [SerializeField] public float bobbingSpeed = 0.18f;  // Speed of the bob
    [SerializeField] public float bobbingAmount = 0.2f;  // How high and low the camera moves
    [SerializeField] public float midpoint = 1.6f;       // Standard height of the camera

    private float timer = 0f;
    private bool isBobbing = false;

    // Function to start or stop bobbing
    public void SetBobbing(bool state)
    {
        isBobbing = state;
        if (!isBobbing)
        {
            timer = 0f;  // Reset timer when stopping
            transform.localPosition = new Vector3(transform.localPosition.x, midpoint, transform.localPosition.z);
        }
    }

    void Update()
    {
        if (isBobbing)
        {
            float waveslice = Mathf.Sin(timer);
            timer += Time.deltaTime * bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer -= (Mathf.PI * 2);
            }

            float verticalOffset = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(verticalOffset);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            verticalOffset = totalAxes * verticalOffset;
            transform.localPosition = new Vector3(transform.localPosition.x, midpoint + verticalOffset, transform.localPosition.z);
        }
    }
}
