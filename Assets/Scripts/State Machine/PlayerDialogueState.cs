using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueState : PlayerBaseState
{
    public PlayerDialogueState(PlayerStateMachine context, PlayerStateFactory playerStateFactory) : base(context, playerStateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        if (!Ctx.IsInDialogue) SwitchState(Factory.Idle());

    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public void HandleGravity()
    {

    }

    public override void InitializeSubState()
    {
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
