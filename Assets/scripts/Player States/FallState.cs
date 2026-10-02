using UnityEngine;

public class FallState : State
{
    float rotationSpeed;


    public FallState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering falling state");

        player.animator.Play("fallAnim");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        float horizontalInput = player.moveAction.ReadValue<Vector2>().x;

        player.rb.linearVelocity = new Vector2(
            horizontalInput * player.moveSpeed,
            player.rb.linearVelocity.y
        );

        if (horizontalInput > 0)
        {
            player.sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            player.sr.flipX = true;
        }

        /*
        UIscript.ui.DrawText("*** This is the falling state ***\n");
        UIscript.ui.DrawText("A/D keys = movement state");
        */
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            sm.ChangeState(sm.idleState);
        }
    }

    public override void FixedUpdate()
    {
        //Fixed Update 
    }
}
