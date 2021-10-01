using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Start_Menu_Handler : MonoBehaviour
{
    [SerializeField] Player_Scriptable playerScriptable;
    [SerializeField] GameObject startMenuPlayer;
    [SerializeField] Text inputNameText;
    [SerializeField] TMP_Text inputErrorText;

    public void OpenSettingsMenu()
    {

    }

    public void OpenCreditsMenu()
    {

    }

    public void SetPlayerName()
    {
        if(!inputNameText.text.Equals(""))
        {
            playerScriptable.SetName(inputNameText.text.ToString());
            inputErrorText.text = $"The name '{playerScriptable.GetName()}' has been accepted!";
            inputErrorText.enabled = true;
            playerScriptable.nameIsValid = true;
        }
        else
        {
            inputErrorText.text = "Please enter a valid name. (Letters, numbers, spaces and special characters only)";
            inputErrorText.enabled = true;
            playerScriptable.nameIsValid = false;
        }
    }
}
