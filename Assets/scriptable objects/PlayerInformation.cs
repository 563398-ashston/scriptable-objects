using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInformation", menuName = "Scriptable Objects/PlayerInformation")]
public class PlayerInformation : ScriptableObject
{
    public string playerName;
    public int score;
    public float health;
    public int lives;
}
