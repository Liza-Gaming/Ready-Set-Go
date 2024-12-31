using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ButtonHandler buttonHandler;
    [SerializeField] public List<GameObject> arrowUI = new List<GameObject>();
    private HashSet<string> loadedScenes = new HashSet<string>();

    public bool isStoveLoaded = false;
    public bool isWardrobeeLoaded = false;
    public bool isFridgeLoaded = false;
    public bool isDeskLoaded = false;

    public Text taskDisplay;
    [SerializeField] private int numOfTatsks = 4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            UpdateTaskDisplay();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool IsSceneLoaded(string sceneName)
    {
        return loadedScenes.Contains(sceneName);
    }

    public void MarkSceneAsLoaded(string sceneName)
    {
        loadedScenes.Add(sceneName);
        UpdateTaskDisplay();
    }

    private void UpdateTaskDisplay()
    {
        if (taskDisplay != null)
            taskDisplay.text = $"{loadedScenes.Count}/{numOfTatsks}"; // Update the UI text to show progress
    }

    private void OnDestroy()
    {
        UpdateTaskDisplay();
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is "SampleScene" with index 1
        if (scene.buildIndex == 1)
        {
            // Show arrows
            buttonHandler.OnPointerUp();
            foreach (var arrow in arrowUI)
            {
                if (arrow != null) arrow.SetActive(true);
            }
        }
        else
        {
            foreach (var arrow in arrowUI)
            {
                if (arrow != null) arrow.SetActive(false);
            }
        }
    }
}
