using UnityEngine;
using System.Collections;

public class MissionTrigger : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UpdateMissionText(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        UpdateMissionText(other, false);
    }

    private void OnDestroy()
    {
        if (UIManager.instance != null && UIManager.instance.mission != null)
        {
            UIManager.instance.mission.gameObject.SetActive(false);
        }
    }

    private void UpdateMissionText(Collider other, bool isEntering)
    {
        if (other.tag == "Bonus")
        {
            audioManager.PlaySFX(audioManager.collectBall);
            UIManager.instance.bonusText.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(ShowFeedback());
        }

        if (UIManager.instance != null && UIManager.instance.taskImages.Count > 0)
        {
            foreach (var taskImage in UIManager.instance.taskImages)
            {
                if (taskImage.tag == other.tag)
                {
                    if (isEntering)
                    {
                        // **Show the corresponding task image**
                        UIManager.instance.mission.sprite = taskImage.sprite; // Assign the correct image
                        UIManager.instance.mission.gameObject.SetActive(true); // Show the image
                    }
                    else
                    {
                        UIManager.instance.mission.gameObject.SetActive(false); // Hide when leaving
                    }
                    return;
                }
            }
        }
    }

    private IEnumerator ShowFeedback()
    {
        yield return new WaitForSeconds(3);
        UIManager.instance.bonusText.gameObject.SetActive(false);
    }
}
