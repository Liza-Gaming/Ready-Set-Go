using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private List<GameObject> arrowUI;
    public GameObject hint;
    public GameObject paper;
    public Text mission;
    [SerializeField] public List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    public Color completedTaskColor = new Color(0.5f, 0.7f, 0.2f, 1f);
    [SerializeField] public TextMeshProUGUI endMission;
    [SerializeField] public TextMeshProUGUI bonusText;

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

    public void UpdateMissionText(string missionText)
    {
        if (mission != null)
        {
            mission.text = missionText;
        }
    }

    public void ShowHint(string hintText)
    {
        if (hintCoroutine != null)
        {
            StopCoroutine(hintCoroutine);
        }
        hintCoroutine = StartCoroutine(DisplayHintForSeconds(hintText, 5f));
    }

    private IEnumerator DisplayHintForSeconds(string hintText, float duration)
    {
        mission.text = hintText;
        mission.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        mission.gameObject.SetActive(false);
    }

    public void Reset()
    {
        taskTexts.Clear();
        Destroy(gameObject);
        instance = null;
    }
}
