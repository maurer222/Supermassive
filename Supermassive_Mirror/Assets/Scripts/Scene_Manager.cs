using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] Player_Scriptable playerScriptable;
    [SerializeField] TMP_Text inputErrorText;

    private static Scene_Manager _instance;
    private static Scene_Manager Instance {get { return _instance; } }

    public void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }
    public void LoadMainGameplayScene()
    {
        if (playerScriptable.nameIsValid == true)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            inputErrorText.text = "Please enter a valid name. (Letters, numbers, spaces and special characters only)";
            inputErrorText.enabled = true;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
