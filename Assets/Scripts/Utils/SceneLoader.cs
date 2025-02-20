using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Loads the scens (missions)
 */
public class SceneLoader : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public string sceneName; // The name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!SceneController.instance.IsSceneLoaded(sceneName))
            {
                SceneController.instance.MarkSceneAsLoaded(sceneName);
                UIManager.instance.MarkTaskAsDone(sceneName);
                if (sceneName != "OpenDoor")
                {
                    Destroy(gameObject);
                }
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}