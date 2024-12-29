using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ButtonHandler buttonHandler;
    public GameObject arrowUI; // Reference to the arrow UI GameObject

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
            if (arrowUI != null) arrowUI.SetActive(true);
        }
        else
        {
            // Hide arrows
            if (arrowUI != null) arrowUI.SetActive(false);
        }
    }
}
