using UnityEngine;

/**
 * Saves the player state across scenes.
 */
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

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

    public void Reset()
    {
        Destroy(gameObject);
        instance = null;
    }

}