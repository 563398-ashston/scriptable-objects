using UnityEngine;
using TMPro;

public class DataOutput : MonoBehaviour
{
    public PlayerInformation PlayerInformation;
    public TextMeshProUGUI textMeshPro;


    void Update()
    {
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        textMeshPro.text = 
        "player name: " + PlayerInformation.playerName +
        " player score: " + PlayerInformation.score +
        " player health: " + PlayerInformation.health+
        " player lives: " + PlayerInformation.lives;
    }
}
