using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{

    public void PlayAgain()
    {
        if (SceneController.instance != null)
        {
            SceneController.instance.Reset();
        }
        if (PlayerManager.instance != null)
        {
            PlayerManager.instance.Reset();
        }
        if (Timer.Instance != null)
        {
            Timer.Instance.ResetTimer();
        }
        if (UIManager.instance != null)
        {
            UIManager.instance.Reset();
        }
        SceneManager.LoadScene("ChooseTime");
    }
}
