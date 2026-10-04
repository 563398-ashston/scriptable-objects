using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //player values
    public float moveSpeed = 6f;
    public float jumpStrength = 7f;
    


    public PlayerInformation playerInformation;

    StateMachine sm;

    public Animator animator;

    //define the actions
    public InputAction moveAction;
    public InputAction jumpAction;
    public InputAction interactAction;
    public InputAction attackAction;
    public InputAction scoreUpAction;
    public InputAction scoreDownAction;



    private void Start()
    {
        sm = new StateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        sm.Init(sm.idleState); //this will be the first state to run 

        //initialise the actions
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        scoreUpAction = InputSystem.actions.FindAction("ScoreUp");
        scoreDownAction = InputSystem.actions.FindAction("ScoreDown");

    }

    private void Update()
    {
        sm.Update();

        if (scoreDownAction.WasPressedThisFrame())
        {
            playerInformation.score = playerInformation.score - 2;
        }

        if (scoreUpAction.WasPressedThisFrame())
        {
            playerInformation.score = playerInformation.score + 2;
        }
    }

    private void FixedUpdate()
    {
        //do not put any of your own methods here - they go in the state files
        sm.FixedUpdate();
    }

    //add your additional collision handling here
    void OnCollisionEnter2D(Collision2D collision)
    {
        sm.currentState.OnCollisionEnter2D(collision);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        sm.currentState.OnTriggerEnter2D(collision);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        sm.currentState.OnTriggerExit2D(collision);
    }
}