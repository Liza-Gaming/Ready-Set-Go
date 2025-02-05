using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Moves the list up or down when the mouse is on it
 */
public class HoverMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverPositionOffset = new Vector3(0, 100, 0);
    private Vector3 originalPosition;
    private bool isHovering = false;

    [SerializeField]
    private float hoverSpeed = 100f;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (isHovering)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originalPosition + hoverPositionOffset, hoverSpeed * Time.deltaTime);
        else
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originalPosition, hoverSpeed * Time.deltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
