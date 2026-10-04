using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    public PlayerInformation PlayerInformation;


    public InputAction healthUpAction;
    public InputAction healthDownAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthUpAction = InputSystem.actions.FindAction("HealthUp");
        healthDownAction = InputSystem.actions.FindAction("HealthDown");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthUpAction.WasPressedThisFrame())
        {
           PlayerInformation.health = PlayerInformation.health + 2;
        }

        if (healthDownAction.WasPressedThisFrame())
        {
            PlayerInformation.health = PlayerInformation.health - 2;
        }
    }
}
