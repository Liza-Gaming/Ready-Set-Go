using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/**
 * Responsible for all the buttons and texts in the main scene.
 */
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private List<GameObject> arrowUI; // moving arrows
    public GameObject hint;// hint button
    public GameObject paper;// list
    public Image mission;// mission name when the player is near the mission
    [SerializeField] private List<Image> HintImages = new List<Image>();// hints
    [SerializeField] public List<Image> taskImages = new List<Image>();// mission name
    [SerializeField] public List<GameObject> taskCheckmarks = new List<GameObject>(); // List of checkmark images V
    [SerializeField] public Image bonusText;

    private Coroutine hintCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ToggleArrows(bool showArrows)
    {
        foreach (var arrow in arrowUI)
        {
            if (arrow != null) arrow.SetActive(showArrows);
        }
        if (hint != null) hint.SetActive(showArrows);
    }

    public void ShowTasks(bool show)
    {
        paper.gameObject.SetActive(show);
    }

    public void MarkTaskAsDone(string sceneName)
    {
        for (int i = 0; i < taskImages.Count; i++)
        {
            if (taskImages[i].tag == sceneName)
            {
                if (taskCheckmarks.Count > i && taskCheckmarks[i] != null)
                {
                    taskCheckmarks[i].SetActive(true);
                }
                return;
            }
        }
        Debug.LogWarning("No task found with tag: " + sceneName);
    }

    public void ShowHintImage(Image hintImage)
    {
        if (hintImage != null)
        {
            // Hide all hint images first
            foreach (Image img in HintImages)
            {
                img.gameObject.SetActive(false);
            }

            // Show the correct hint image
            hintImage.gameObject.SetActive(true);

            // Start coroutine to hide after 3 seconds
            StartCoroutine(HideHintAfterSeconds(hintImage, 3f));
        }
    }

    private IEnumerator HideHintAfterSeconds(Image hintImage, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (hintImage != null)
        {
            hintImage.gameObject.SetActive(false); // Hide the hint image
        }
    }


    public void Reset()
    {
        taskImages.Clear();
        Destroy(gameObject);
        instance = null;
    }
}
