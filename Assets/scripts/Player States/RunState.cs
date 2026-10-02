using UnityEngine;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 6;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running state");

        player.animator.Play("runAnim");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        float horizontalInput = player.moveAction.ReadValue<Vector2>().x;

        if (horizontalInput == 0)
        {
            sm.ChangeState(sm.idleState);
            return;
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
            return;
        }

        player.rb.linearVelocity = new Vector2(
            horizontalInput * player.moveSpeed,
            player.rb.linearVelocity.y
        );

        // Flip sprite
        if (horizontalInput > 0)
        {
            player.sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            player.sr.flipX = true;
        }

        /*
        UIscript.ui.DrawText("*** This is the running state ***\n");
        UIscript.ui.DrawText("stop moving = idle state");
        UIscript.ui.DrawText("left mouse button = attack");
        UIscript.ui.DrawText("space = jump state");
        */
    }

    public override void FixedUpdate()
    {
    }
}
