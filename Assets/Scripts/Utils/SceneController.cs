using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
/**
 * Tracks the progress of the scenes and also keeps the house from being destroyed.
 */
public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ButtonHandler buttonHandler;
    private HashSet<string> loadedScenes = new HashSet<string>();
    [SerializeField] private List<Image> HintImages = new List<Image>();
    [SerializeField] private int numOfTasks = 5;
    [SerializeField] private GameObject finalScene;
    [SerializeField] private GameObject sunscreenObject;
    [SerializeField] private GameObject purseObject;
    [SerializeField] private Image FinalHint;
    private string nextSceneName;

    [SerializeField]
    private List<string> relevantScenes = new List<string>();

    // Dictionary to store mission hint images
    private Dictionary<string, Image> missionHints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Ensure HintImages has enough elements before accessing indexes
            missionHints = new Dictionary<string, Image>();

            if (HintImages.Count > 0) missionHints["Stove"] = HintImages[0];
            if (HintImages.Count > 1) missionHints["Fridge"] = HintImages[1];
            if (HintImages.Count > 2) missionHints["Wardrobe"] = HintImages[2];
            if (HintImages.Count > 3) missionHints["Desk"] = HintImages[3];
            if (HintImages.Count > 4) missionHints["Towel"] = HintImages[4];
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
        if (sceneName == "Desk")
        {
            sunscreenObject.SetActive(false);
            purseObject.SetActive(false);
        }
    }

    public Image GetFirstUnloadedSceneHint()
    {
        foreach (string sceneName in relevantScenes)
        {
            if (!loadedScenes.Contains(sceneName))
            {
                if (missionHints.TryGetValue(sceneName, out Image hintImage))
                {
                    return hintImage;
                }
            }
        }
        return FinalHint;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.instance.ShowTasks(scene.buildIndex == 1);
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
        Image hintImage = SceneController.instance.GetFirstUnloadedSceneHint();
        if (hintImage != null)
        {
            UIManager.instance.ShowHintImage(hintImage);
        }
    }


    public void Reset()
    {
        loadedScenes.Clear();
        finalScene.SetActive(false);
        Destroy(gameObject);
        instance = null;
    }
}
