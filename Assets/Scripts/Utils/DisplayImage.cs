using System.Collections;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public GameObject imageObject; // Assign your main Image GameObject here in the inspector
    public GameObject backgroundObject; // Assign your Background Image GameObject here in the inspector
    public float displayDuration = 5.0f;

    void Start()
    {
        StartDisplay(); // Changed to a method call for initial display
    }

    public void StartDisplay()
    {
        StartCoroutine(DisplayForSeconds(displayDuration)); // Start the coroutine properly
    }

    private IEnumerator DisplayForSeconds(float seconds)
    {
        backgroundObject.SetActive(true);
        imageObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        imageObject.SetActive(false);
        backgroundObject.SetActive(false);
    }
}
