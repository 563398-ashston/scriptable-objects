
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using System.Collections;

public class IdleState : State
{
    // constructor
    public IdleState( PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering idle state");

        player.animator.Play("idleAnim");

        // Stop horizontal movement
        player.rb.linearVelocity = new Vector2(0,player.rb.linearVelocity.y);
    }

    public override void Exit()
    {
        Debug.Log("exiting idle state");

        player.StopAllCoroutines();
    }


    public override void Update()
    {
        float horizontalInput = player.moveAction.ReadValue<Vector2>().x;

        if (horizontalInput != 0)
        {
            sm.ChangeState(sm.runState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        /*
        UIscript.ui.DrawText("*** This is the idle state ***\n");
        UIscript.ui.DrawText("A/D keys = movement state");
        UIscript.ui.DrawText("left mouse button = attack");
        UIscript.ui.DrawText("Space = jump state");
        */

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
            return;
        }
    }

    public override void FixedUpdate()
    {
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
    }


    public IEnumerator IdleCo()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine step 1");

            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine step 2");

            Debug.Log("Coroutine repeat " + (i+1));

        }
        yield break;
    }




}
