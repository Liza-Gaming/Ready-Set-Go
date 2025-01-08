using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ButtonHandler buttonHandler;
    private HashSet<string> loadedScenes = new HashSet<string>();
    [SerializeField] private int numOfTasks = 5;

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
    }
}
