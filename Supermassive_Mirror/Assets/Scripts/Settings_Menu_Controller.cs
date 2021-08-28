using UnityEngine;

public class Settings_Menu_Controller : MonoBehaviour
{
    public void OpenSettingsMenu()
    {
        GameObject.Find("Settings Menu Panel").SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        GameObject.Find("Settings Menu Panel").SetActive(false);
    }
}
