using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void OpenMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void OpenGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void OpenTestPoligon()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestPoligon");
    }
}
