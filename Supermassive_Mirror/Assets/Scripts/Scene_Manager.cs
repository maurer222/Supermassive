using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    private static Scene_Manager _instance;
    private static Scene_Manager Instance {get { return _instance; } }

    public void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMainGameplayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSettingScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadCreditScene()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
