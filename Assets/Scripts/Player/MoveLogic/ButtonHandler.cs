using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Moving logic with the mouse
 */

public class ButtonHandler : MonoBehaviour
{
    public Movement movement;
    public bool forwardPressed;
    public CameraBob cameraBob;

    public void OnPointerDown()
    {
        movement.MoveForward(true);
        cameraBob.SetBobbing(true);
        forwardPressed = true;
    }

    public void OnPointerUp()
    {
        movement.MoveForward(false);
        cameraBob.SetBobbing(false);
        forwardPressed = false;
    }

    void Update()
    {
        if (forwardPressed)
        {
            movement.MoveForward(true);
            cameraBob.SetBobbing(true);
        }
    }
}
