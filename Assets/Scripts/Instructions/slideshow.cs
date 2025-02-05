using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Shows the instructions in slide show way
 */
public class slideshow : MonoBehaviour
{
    public Image instructionImage;
    public Sprite[] instructionSprites;
    public string nextSceneName;
    private int currentIndex = 0;

    void Start()
    {
        if (instructionSprites.Length > 0)
            instructionImage.sprite = instructionSprites[currentIndex];
    }

    public void NextImage()
    {
        if (currentIndex < instructionSprites.Length - 1)
        {
            StartCoroutine(FadeImage());
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // Load next scene
        }
    }

    IEnumerator FadeImage()
    {
        // Fade out
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            instructionImage.color = new Color(1, 1, 1, i);
            yield return null;
        }

        // Change the image
        currentIndex++;
        instructionImage.sprite = instructionSprites[currentIndex];

        // Fade in
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            instructionImage.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

}