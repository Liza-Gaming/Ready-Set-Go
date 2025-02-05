using UnityEngine;

//Got help from: https://www.youtube.com/watch?v=N8whM1GjH4w&t=444s&ab_channel=RehopeGames
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sounds;

    public AudioClip collectBall;
    public AudioClip rightChoise;
    public AudioClip wrongChoise;
    public AudioClip wrongPress;
    public AudioClip rightPress;
    public AudioClip rightClothes;
    public AudioClip wrongClothes;
    public AudioClip missioncompleted;
    public void PlaySFX(AudioClip clip)
    {
        sounds.PlayOneShot(clip);
    }

}
