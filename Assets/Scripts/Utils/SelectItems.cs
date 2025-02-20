using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Used in collection missions
 */
public class SelectItems : MonoBehaviour
{
    public GameObject[] interactableObjects;
    public Text feedbackText;
    [Tooltip("The maximum number of items that can be taken in the scene")]
    [SerializeField] public int items;
    [SerializeField] private string sceneName;
    [SerializeField]
    private Material material;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void ObjectSelected(GameObject selectedObject)
    {

        // Logic to determine if the selection is correct
        // Assuming the "correct" objects have specific names or tags
        if (selectedObject.tag == "Collectable")
        {
            audioManager.PlaySFX(audioManager.rightChoise);
            feedbackText.color = Color.green;
            selectedObject.SetActive(false);
            feedbackText.text = "Correct choice!";
            StartCoroutine(ShowFeedback());
        }
        else
        {
            audioManager.PlaySFX(audioManager.wrongChoise);
            feedbackText.color = Color.red;
            feedbackText.text = "Wrong choice! Try again.";
            StartCoroutine(ShowFeedback());
        }

        CheckCompletion(); // Check if the level is completed
    }

    // Method to check if the level is completed
    void CheckCompletion()
    {
        int inactiveCount = 0;

        foreach (var obj in interactableObjects)
        {
            if (!obj.activeSelf)
            {
                inactiveCount++;
            }
        }

        // Check if the required number of objects are inactive
        if (inactiveCount >= items)
        {
            feedbackText.color = Color.green;
            feedbackText.text = "Level Completed!";
            StartCoroutine(ShowFeedback());
            if (sceneName == "OpenDoor")
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                audioManager.PlaySFX(audioManager.rightChoise);
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void ResetObjects()
    {
        foreach (var obj in interactableObjects)
        {
            if (!obj.active)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = material;
                }
                obj.SetActive(true); // Reactivate all objects
            }
        }
    }

    private IEnumerator ShowFeedback()
    {
        yield return new WaitForSeconds(2);
        feedbackText.text = "";
    }
}
