using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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

    public void MarkSceneAsLoaded(string sceneName)
    {
        loadedScenes.Add(sceneName);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe when destroyed
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
