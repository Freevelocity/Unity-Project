using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {

    }
    public override void EnterState() { }

    public override void UpdateState() 
    {
        CheckSwitchStates();
  
    }
    public override void FixedUpdateState()
    {
        _ctx.animator.SetFloat("Speed", _ctx.rb.velocity.magnitude / _ctx.MaxSpeed);

        _ctx.forceDirection += _ctx.inputVector.x * GetCameraRight(_ctx._playerCamera) * _ctx.MovementSpeed;
        _ctx.forceDirection += _ctx.inputVector.y * GetCameraForward(_ctx._playerCamera) * _ctx.MovementSpeed;
        _ctx.rb.AddForce(_ctx.forceDirection, ForceMode.Impulse);
        _ctx.forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = _ctx.rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _ctx.MaxSpeed * _ctx.MaxSpeed)
        {
            _ctx.rb.velocity = horizontalVelocity.normalized * _ctx.MaxSpeed + Vector3.up * _ctx.rb.velocity.y;
        }

      

    }

    public override void ExitState() { }

    public override void CheckSwitchStates()
    {
        if (!_ctx.IsMovementPressed)
        {
            SwitchState(_factory.Idle());
        

        }
    }

    public override void InitializeSubStates()
    {
       
    }

    private Vector3 GetCameraForward(Camera playerCamera) //Turns regardless of camera orentation.
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera) //Turns regardless of camera orentation.
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

}
