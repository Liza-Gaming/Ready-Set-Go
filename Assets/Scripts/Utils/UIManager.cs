using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private List<GameObject> arrowUI;
    public GameObject paper;
    [SerializeField] private List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    public Color completedTaskColor = new Color(0.5f, 0.7f, 0.2f, 1f);

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
    }

    public void ShowTasks(bool show)
    {
        paper.gameObject.SetActive(show);
    }

    public void MarkTaskAsDone(string sceneName)
    {
        foreach (TextMeshProUGUI task in taskTexts)
        {
            if (task.tag == sceneName)
            {
                task.color = completedTaskColor;
                return;
            }
        }
        Debug.LogWarning("No task found with tag: " + sceneName);
    }
}