using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GhostRealmExit : MonoBehaviour
{
    public GameObject winText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ReturnToRealRealm());
        }
    }

    IEnumerator ReturnToRealRealm()
    {
        winText.SetActive(true);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("SampleScene");
    }
}