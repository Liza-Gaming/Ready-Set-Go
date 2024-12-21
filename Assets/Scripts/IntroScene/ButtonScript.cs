using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Button loadSceneButton;  // Assign through inspector
    private float delayTime = 32f;

    void Start()
    {
        if (loadSceneButton != null)
        {
            loadSceneButton.gameObject.SetActive(false); // Hide the button initially
            loadSceneButton.onClick.AddListener(OnButtonClick); // Add listener for button click
        }

        // Start the coroutine to show the button after a delay
        StartCoroutine(ShowButtonAfterDelay());
    }

    private System.Collections.IEnumerator ShowButtonAfterDelay()
    {
        yield return new WaitForSeconds(delayTime); // Wait for 32 seconds
        if (loadSceneButton != null)
        {
            loadSceneButton.gameObject.SetActive(true); // Show the button
        }
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene("SampleScene"); // Load the scene named "SampleScene"
    }
}