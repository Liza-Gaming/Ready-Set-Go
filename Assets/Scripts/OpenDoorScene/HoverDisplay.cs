using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Displays an image when the mouse is above an object
 */

public class HoverDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imageToDisplay;

    private void Start()
    {
        imageToDisplay.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageToDisplay.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageToDisplay.SetActive(false);
    }
}
