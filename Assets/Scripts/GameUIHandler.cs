using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    // Insert code for timer and ui representation
    public Text timerText;
    private float seconds = 0;
    public bool gameOver = false;

    void Update()
    {
        if (!gameOver)
        {
            seconds += Time.deltaTime;
            DisplayTime(seconds);
        }
    }

    void DisplayTime(float timeToDisplay) // ABSTRACTION
    {
        // Format time as minutes:seconds
        timerText.text = "Time Survived: " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeToDisplay / 60), Mathf.FloorToInt(timeToDisplay % 60));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }


}
