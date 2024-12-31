using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ButtonHandler buttonHandler; // Assumes there's a button handler logic still needed here
    private HashSet<string> loadedScenes = new HashSet<string>();
    [SerializeField] private int numOfTasks = 4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            UIManager.instance.UpdateTaskDisplay(loadedScenes.Count, numOfTasks);
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
        UIManager.instance.UpdateTaskDisplay(loadedScenes.Count, numOfTasks);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            // Show arrows
            buttonHandler.OnPointerUp();
        }
        UIManager.instance.UpdateTaskDisplay(loadedScenes.Count, numOfTasks);
        UIManager.instance.ToggleArrows(scene.buildIndex == 1); // Assume 1 is SampleScene where arrows need to be active
    }
}
