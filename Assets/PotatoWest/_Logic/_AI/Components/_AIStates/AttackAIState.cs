using System.Collections;
using System.Collections.Generic;
using PotatoWest._Logic._AI.Components._AIStates;
using UnityEngine;

public class AttackAIState : AiCharacterState
{
    public override void Enter()
    {
        var player = Context.Level.Player;
        Context.Mover.MoveToWaypoint(transform.position + transform.forward * 5f, Context.Parameters.MoveSpeed);
        Context.ShootController.Target = player.transform;
        Context.ShootController.IsAiming = true;
    }

    public override void Exit()
    {
        base.Exit();
        Context.Mover.Stop();
        Context.ShootController.IsAiming = false;
    }
}