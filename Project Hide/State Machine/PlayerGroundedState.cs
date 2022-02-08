using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubStates();
    }
    public override void EnterState() 
    {
       if(_ctx.IsJumping)
        {
            _ctx.IsJumping = false;
        }
    
    }


    public override void UpdateState() 
    {
        CheckSwitchStates();
      
    }
    public override void FixedUpdateState()
    {

    }

    public override void ExitState() 
    {
       
    }

    public override void CheckSwitchStates() 
    {
        if(_ctx.IsJumpingPressed)
        {
            SwitchState(_factory.Jump());  // This will inovke the jump on the PlayerStateFactory and will create a new instance of JumpScript

        }
      
    }

    public override void InitializeSubStates()
    {
        if(!_ctx.IsMovementPressed)
        {
            SetSubState(_factory.Idle());
     
        
        }
        else
        {
            SetSubState(_factory.Run());
            

        }    
    }

}
