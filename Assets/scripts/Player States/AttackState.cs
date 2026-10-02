using UnityEngine;

public class AttackState : State
{
    float attackTimer;
    public float attackDuration = 0.3f;

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering attack state");

        player.animator.Play("attackAnim");

        // Get the length of the Attack animation
        attackTimer = attackDuration;

        //UIscript.ui.DrawText("*** This is the attack state ***");
    }

    public override void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            sm.ChangeState(sm.idleState);
            return;
        }

        /*
        UIscript.ui.DrawText("*** This is the attack state ***\n");
        UIscript.ui.DrawText("stop moving = idle state");
        UIscript.ui.DrawText("space = jump state");
        */
    }

    public override void Exit()
    {
        Debug.Log("exiting attack state");
    }

    public override void FixedUpdate()
    {
    }
}