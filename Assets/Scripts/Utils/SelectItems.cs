using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SelectItems : MonoBehaviour
{
    public GameObject[] interactableObjects;
    public Text feedbackText;
    [SerializeField] public int items;
    [SerializeField] private string sceneName;
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

    private IEnumerator ShowFeedback()
    {
        yield return new WaitForSeconds(2);
        feedbackText.text = "";
    }
}
