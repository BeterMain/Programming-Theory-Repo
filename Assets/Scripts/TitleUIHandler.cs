using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIHandler : MonoBehaviour
{

    public void StartNew()
    {
        // Load game level
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
