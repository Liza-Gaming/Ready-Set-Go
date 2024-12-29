using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class selectItems : MonoBehaviour
{
    public GameObject[] interactableObjects; 
    public Text feedbackText; 

    // Method to call when an object is selected
    public void ObjectSelected(GameObject selectedObject)
    {

        // Logic to determine if the selection is correct
        // Assuming the "correct" objects have specific names or tags
        if (selectedObject.tag == "Collectable")
        {
            feedbackText.color = Color.green;
            selectedObject.SetActive(false);
            feedbackText.text = "Correct choice!";
            StartCoroutine(ShowFeedback());
        }
        else
        {
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
        if (inactiveCount >= 2) // Change this value based on your game's logic
        {
            feedbackText.color = Color.green;
            feedbackText.text = "Level Completed!";
            StartCoroutine(ShowFeedback());
            SceneManager.LoadScene("SampleScene");


        }
    }

    private IEnumerator ShowFeedback()
    {
        yield return new WaitForSeconds(2);
        feedbackText.text = "";
    }
}
