using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject rulesPanel;

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartTheGame()
    {
        rulesPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}