using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ButtonHandler buttonHandler;
    private HashSet<string> loadedScenes = new HashSet<string>();
    [SerializeField] private int numOfTasks = 5;
    [SerializeField] private GameObject finalScene;
    [SerializeField] private GameObject sunscreenObject;
    [SerializeField] private GameObject purseObject;
    private string nextSceneName;

    [SerializeField]
    private List<string> relevantScenes = new List<string>();

    // Store mission descriptions
    private Dictionary<string, string> missionDescriptions = new Dictionary<string, string>
    {
        { "Stove", "Are you hungry for brakfast?" },
        { "Fridge", "Everyone loves cold, refreshing fruits." },
        { "Wardrobe", "Where do you find clothes?" },
        { "Desk", "Don't forget the things on the table!" },
        { "Towel", "Towel is needed not only after a bath." }
    };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
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

    public void SetNextSceneName(string sceneName)
    {
        nextSceneName = sceneName;
    }

    public void MarkSceneAsLoaded(string sceneName)
    {
        loadedScenes.Add(sceneName);
        if (sceneName == "Desk") // Check if the Desk scene has been completed
        {
            sunscreenObject.SetActive(false); // Hide SunScreen
            purseObject.SetActive(false);     // Hide Purse
        }
    }

    public string GetFirstUnloadedSceneDescription()
    {
        foreach (string sceneName in relevantScenes)
        {
            if (!loadedScenes.Contains(sceneName))
            {
                if (missionDescriptions.TryGetValue(sceneName, out string description))
                {
                    return description;
                }
            }
        }
        return "Go to the exit door.";
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.instance.ShowTasks(scene.buildIndex == 1); // Show tasks only in main scene
        UIManager.instance.ToggleArrows(scene.buildIndex == 1);
        if (scene.buildIndex == 1)
        {
            buttonHandler.OnPointerUp();
        }
        if (loadedScenes.Count == numOfTasks && scene.buildIndex == 1)
        {
            finalScene.SetActive(true);
        }
    }

    public void OnHintButtonClicked()
    {
        string missionText = SceneController.instance.GetFirstUnloadedSceneDescription();
        UIManager.instance.ShowHint(missionText);
    }

    public void Reset()
    {
        loadedScenes.Clear();
        finalScene.SetActive(false);
        Destroy(gameObject);
        instance = null;
    }
}
