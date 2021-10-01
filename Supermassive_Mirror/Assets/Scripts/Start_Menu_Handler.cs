using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Start_Menu_Handler : MonoBehaviour
{
    [SerializeField] Player_Scriptable playerScriptable;
    [SerializeField] GameObject startMenuPlayer;
    [SerializeField] Text inputNameText;
    [SerializeField] TMP_Text inputErrorText;
    [SerializeField] TMP_Text playerNameText;

    private void Start()
    {
        if(playerScriptable.GetName() != null)
        {
            playerNameText.text = playerScriptable.GetName();
        }
    }

    public void OpenSettingsMenu()
    {
        //Bring up the Settings Menu
    }

    public void OpenCreditsMenu()
    {
        //Bring up the Credits Menu
    }

    public void SetPlayerName()
    {
        if(!inputNameText.text.Equals(""))
        {
            playerScriptable.SetName(inputNameText.text.ToString());
            inputErrorText.text = $"The name '{playerScriptable.GetName()}' has been accepted!";
            inputErrorText.enabled = true;
            playerScriptable.nameIsValid = true;
            playerNameText.text = playerScriptable.GetName();
        }
        else
        {
            inputErrorText.text = "Please enter a valid name. (Letters, numbers, spaces and special characters only)";
            inputErrorText.enabled = true;
            playerScriptable.nameIsValid = false;
            playerNameText.text = "Invalid Name";
        }
    }
}
