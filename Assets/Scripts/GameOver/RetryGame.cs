using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    public Button retry;  // Assign through inspector

    void Start()
    {
        if (retry != null)
        {
            retry.onClick.AddListener(OnButtonClick); // Add listener for button click
        }
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Intro"); // Load the scene named "SampleScene"
    }
}
