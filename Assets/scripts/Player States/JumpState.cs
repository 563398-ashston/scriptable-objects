using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering jumping state");

        player.animator.Play("jumpAnim");

        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x,player.jumpStrength);

        //UIscript.ui.DrawText("*** This is the jumping state ***");
    }

    public override void Exit()
    {
        Debug.Log("exiting jumping state");
    }

    public override void Update()
    {
        float horizontalInput = player.moveAction.ReadValue<Vector2>().x;

        player.rb.linearVelocity = new Vector2(horizontalInput * player.moveSpeed,player.rb.linearVelocity.y);

        if (horizontalInput > 0)
        {
            player.sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            player.sr.flipX = true;
        }

        if (player.rb.linearVelocity.y < 0)
        {
            sm.ChangeState(sm.fallState);
            return;
        }

        /*
        UIscript.ui.DrawText("*** This is the jumping state ***\n");
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
    }
}