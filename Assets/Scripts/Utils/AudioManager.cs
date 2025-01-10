using UnityEngine;


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
