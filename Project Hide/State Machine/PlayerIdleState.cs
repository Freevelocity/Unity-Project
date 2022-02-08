using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    protected bool StartLerp;
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) 
    {
        // This base passes the arguemnts on this constructor to the baseState directly. 
    }

    public override void EnterState()
    {
        _ctx.animator.SetFloat("Speed", Mathf.Lerp(_ctx.rb.velocity.magnitude / _ctx.MaxSpeed, 0, 2f));


    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void FixedUpdateState()
    {
        
      
    }


    public override void ExitState() { }

    public override void CheckSwitchStates()
    {
        if (_ctx.IsMovementPressed)
        {
            SwitchState(_factory.Run());
        }
    }

    public override void InitializeSubStates()
    {
      
    }

}
