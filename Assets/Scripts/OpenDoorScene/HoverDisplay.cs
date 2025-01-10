using UnityEngine;
using UnityEngine.EventSystems;

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
