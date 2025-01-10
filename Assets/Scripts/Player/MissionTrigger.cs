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
        // Clear the mission text when the GameObject with this script is destroyed
        if (UIManager.instance != null && UIManager.instance.mission != null)
        {
            UIManager.instance.mission.gameObject.SetActive(false);
        }
    }

    // Method to update the mission text based on entering or exiting the trigger
    private void UpdateMissionText(Collider other, bool isEntering)
    {
        if (other.tag == "Bonus")
        {
            audioManager.PlaySFX(audioManager.collectBall);
            UIManager.instance.bonusText.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(ShowFeedback());
        }
        if (UIManager.instance != null && UIManager.instance.taskTexts.Count > 0)
        {
            foreach (var taskText in UIManager.instance.taskTexts)
            {
                if (taskText.tag == other.tag)
                {
                    if (isEntering)
                    {
                        UIManager.instance.mission.text = taskText.text;
                        UIManager.instance.mission.gameObject.SetActive(true); // Ensure the mission text is visible
                    }
                    else
                    {
                        UIManager.instance.mission.gameObject.SetActive(false); // Hide the mission text
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
