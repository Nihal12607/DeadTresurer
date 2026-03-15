using UnityEngine;
using TMPro;   // only needed if using TextMeshPro

using UnityEngine.SceneManagement;
public class FinishZone : MonoBehaviour
{
    public GameObject winText;   // UI text object

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // destroy all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            // show win text
            winText.SetActive(true);
        }
        SceneManager.LoadScene("SampleScene");
    }
}