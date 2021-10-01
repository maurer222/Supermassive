using UnityEngine;

[CreateAssetMenu]
public class Player_Scriptable : ScriptableObject
{
    public string playerName;
    public bool nameIsValid;
    
    public Color[] colorOption = { Color.black, Color.grey, Color.red, Color.green, Color.blue, Color.yellow };
    private Color playerColor;
    private int colorIndex = 0;

    public GameObject[] effectOption;
    private GameObject playerEffect;
    private int effectIndex = 0;

    public void SetName(string name)
    {
        playerName = name;
    }

    public string GetName()
    {
        return playerName;
    }

    public void NextColor()
    {
        if(colorIndex < colorOption.Length - 1)
        {
            colorIndex++;
            playerColor = colorOption[colorIndex];
            GameObject.Find("Start Menu Player").GetComponent<Renderer>().material.color = playerColor;
        }
        else
        {
            colorIndex = 0;
            playerColor = colorOption[colorIndex];
            GameObject.Find("Start Menu Player").GetComponent<Renderer>().material.color = playerColor;
        }
    }

    public void PreviousColor()
    {
        if (colorIndex > 0)
        {
            colorIndex--;
            playerColor = colorOption[colorIndex];
            GameObject.Find("Start Menu Player").GetComponent<Renderer>().material.color = playerColor;
        }
        else
        {
            colorIndex = colorOption.Length - 1;
            playerColor = colorOption[colorIndex];
            GameObject.Find("Start Menu Player").GetComponent<Renderer>().material.color = playerColor;
        }
    }

    public Color GetPlayerColor()
    {
        return playerColor;
    }

    public void NextPlayerEffect()
    {
        Vector3 playerModel = GameObject.Find("Start Menu Player").transform.position;
        Vector3 playerModelScale = new Vector3(2, 2, 2);

        if (effectIndex < effectOption.Length - 1)
        {
            effectIndex++;
            playerEffect = effectOption[effectIndex];
            GameObject gObj = Instantiate(playerEffect, playerModel, Quaternion.identity) as GameObject;
            gObj.transform.localScale = playerModelScale;
        }
        else
        {
            effectIndex = 0;
            playerEffect = effectOption[effectIndex];
            GameObject gObj = Instantiate(playerEffect, playerModel, Quaternion.identity) as GameObject;
            gObj.transform.localScale = playerModelScale;
        }
    }

    public void PreviousPlayerEffect()
    {
        Vector3 playerModel = GameObject.Find("Start Menu Player").transform.position;
        Vector3 playerModelScale = new Vector3(2, 2, 2);

        if (effectIndex > 0)
        {
            effectIndex--;
            playerEffect = effectOption[effectIndex];
            GameObject gObj = Instantiate(playerEffect, playerModel, Quaternion.identity) as GameObject;
            gObj.transform.localScale = playerModelScale;
        }
        else
        {
            effectIndex = effectOption.Length - 1;
            playerEffect = effectOption[effectIndex];
            GameObject gObj = Instantiate(playerEffect, playerModel, Quaternion.identity) as GameObject;
            gObj.transform.localScale = playerModelScale;
        }
    }
}
