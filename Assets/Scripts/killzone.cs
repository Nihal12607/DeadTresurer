using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZoneLoader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnManager.SetRespawn(other.transform.position);
            SceneManager.LoadScene("GhostRealm");
        }
    }
}