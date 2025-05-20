using UnityEngine;

[CreateAssetMenu(fileName = "New Suspect", menuName = "Mystery/Suspect")]
public class Suspect : ScriptableObject
{
    public string suspectName;
    public string suspectSummary;
    public Sprite suspectImage;
    public Color suspectColor;
}