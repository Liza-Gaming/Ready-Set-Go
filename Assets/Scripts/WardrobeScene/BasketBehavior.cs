using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BasketBehavior : MonoBehaviour
{
    int points = 0;
    public Text textToShow;

    public List<ClothingSpawner> spawners; // List to hold all your spawners

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        textToShow.text = "Collect all of the summer items";
    }

    private void OnCollisionEnter(Collision other)
    {
        string clothTag = other.gameObject.tag;
        //Destroy the clothing item that's collected
        if (clothTag == "Summer Hat" || clothTag == "Short Pants" || clothTag == "Sun Glasses" || clothTag == "T Shirt")
        {
            audioManager.PlaySFX(audioManager.rightClothes);
            Destroy(other.gameObject);
            points++;
            textToShow.color = Color.green;
            textToShow.text = "Great!";
            if (points == 5)
            {
                SceneManager.LoadScene("SampleScene");
            }
            //// Iterate over each spawner and remove the corresponding clothing
            //foreach (var spawner in spawners)
            //{
            //    GameObject clothToRemove = null;
            //    foreach (GameObject clothing in spawner.prefabToSpawn)
            //    {
            //        if (clothing.CompareTag(clothTag))
            //        {
            //            clothToRemove = clothing;
            //            break;
            //        }
            //    }

            //    if (clothToRemove != null)
            //    {
            //        spawner.prefabToSpawn.Remove(clothToRemove);
            //    }
            //}
        }
        else if (clothTag == "Sweater" || clothTag == "Socks" || clothTag == "Winter Hat" || clothTag == "Jeans Pants" || clothTag == "UnderPants")
        {
            audioManager.PlaySFX(audioManager.wrongClothes);
            Destroy(other.gameObject);
            textToShow.color = Color.red;
            textToShow.text = "Try again";
        }
    }
}