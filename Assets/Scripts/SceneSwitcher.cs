using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void ToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
