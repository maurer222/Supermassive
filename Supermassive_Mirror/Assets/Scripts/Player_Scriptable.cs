using UnityEngine;

[CreateAssetMenu]
public class Player_Scriptable : ScriptableObject
{
    public string playerName;
    public Material playerSkin;
    public bool nameIsValid;

    public void SetName(string name)
    {
        playerName = name;
    }

    public string GetName()
    {
        return playerName;
    }
}
