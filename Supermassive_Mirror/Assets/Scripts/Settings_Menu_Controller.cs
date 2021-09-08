using UnityEngine;

public class Settings_Menu_Controller : MonoBehaviour
{
    GameObject settingMenu;

    private void Start()
    {
        //settingMenu = GameObject.Find("Settings Menu Panel");
        //settingMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        settingMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingMenu.SetActive(false);
    }
}
