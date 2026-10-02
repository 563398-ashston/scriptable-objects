using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class DataOutput : MonoBehaviour
{
    public PlayerInformation PlayerInformation;
    public TextMeshProUGUI textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayInfo();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInformation.playerName = ("Timmy");
        PlayerInformation.score = 0;
        PlayerInformation.health = 100;
        PlayerInformation.lives = 3;

        Debug.Log(PlayerInformation.playerName);
        Debug.Log(PlayerInformation.score);
        Debug.Log(PlayerInformation.health);
        Debug.Log(PlayerInformation.lives);
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
