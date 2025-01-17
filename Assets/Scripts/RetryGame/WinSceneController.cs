using UnityEngine;
using UnityEngine.UI;

public class WinSceneController : MonoBehaviour
{
    [SerializeField] private Text winText;

    void Start()
    {
        float elapsedTime = Timer.Instance.GetElapsedTime();
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        winText.text = $"You completed the game in {minutes:00}:{seconds:00}.";
    }
}
