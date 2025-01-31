// Script for navigating to the HistoryScene
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateToHistory : MonoBehaviour
{
    [SerializeField] private Button showHistoryButton;

    private void Start()
    {
        showHistoryButton.onClick.AddListener(() => {
            SceneManager.LoadScene("HistoryScene");
        });
    }
}
