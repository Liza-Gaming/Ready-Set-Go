using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
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
}
