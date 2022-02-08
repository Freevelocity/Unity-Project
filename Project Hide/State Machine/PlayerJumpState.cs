using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubStates();
    }
    public override void EnterState() 
    {
        HandleJump();

    }

    public override void UpdateState()
    {
        CheckSwitchStates();

       
      
    }
    public override void FixedUpdateState()
    {
        
        FallingJumpGravity();
        



    }



    public override void ExitState() 
    {
        _ctx.IsJumping = false;
    }

    public override void CheckSwitchStates() 
    {
        if(_ctx.IsGrounded() && !_ctx.IsJumpingPressed)
        {
            SwitchState(_factory.Grounded());
            Debug.Log("Now Grounded");
        }
    }

    public override void InitializeSubStates() 
    {
        if (!_ctx.IsMovementPressed)
        {
            SetSubState(_factory.Idle());
        
           
        }
        else
        {
            SetSubState(_factory.Run());
        

        }
    }

    void HandleJump()
    {

        _ctx.IsJumping = true;
         _ctx.forceDirection.y = _ctx.InitialJumpVelocity;
        _ctx.rb.AddForce(_ctx.forceDirection, ForceMode.Impulse);
        _ctx.forceDirection = Vector3.zero;



    }

    void FallingJumpGravity()
    {
        if (_ctx.rb.velocity.y <= 0.0f)
        {
         
            _ctx.rb.velocity -= Vector3.down * _ctx.JumpingGravity * _ctx.FallMultiplier * Time.fixedDeltaTime;
            

        }
    }

}
