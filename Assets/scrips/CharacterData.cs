using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string jumpAnimtionName = "jump";
    public string moveAnimtionName = "Move";
    public string rollAnimtionName = "Roll";
    public string LoseAnimtionName = "Lose";
    public string runAnimtionName = "Run";
}
