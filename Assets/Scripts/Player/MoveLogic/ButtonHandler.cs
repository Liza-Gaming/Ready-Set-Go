using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour
{
    public Movement movement;
    public bool forwardPressed;


    public void OnPointerDown()
    {
        movement.MoveForward(true);
        forwardPressed = true;
    }

    public void OnPointerUp()
    {
        movement.MoveForward(false);
        forwardPressed = false;
    }

    void Update()
    {
        if (forwardPressed)
        {
            movement.MoveForward(true);
        }
    }
}
