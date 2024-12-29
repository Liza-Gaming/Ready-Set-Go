using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadDesk : MonoBehaviour
{
    public GameObject player;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.tag == "Player" && !SceneController.instance.isDeskLoaded)
        {
            SceneController.instance.isDeskLoaded = true;
            Destroy(gameObject);
            //player.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z + 1);
            SceneManager.LoadScene("Desk");
        }
    }
}

