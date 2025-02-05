using System.Collections;
using UnityEngine;

/**
 * Displays the image in the beginning of the scene
 */
public class DisplayImage : MonoBehaviour
{
    public GameObject imageObject;
    public GameObject backgroundObject;
    public float displayDuration = 5.0f;

    void Start()
    {
        StartDisplay();
    }

    public void StartDisplay()
    {
        StartCoroutine(DisplayForSeconds(displayDuration));
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
