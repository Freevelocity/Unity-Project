
// This is the Abstarct State, which all concreate state inherite from.
// Establishes Methods and Varibles that concreate states will inherit when derived from this class.
// Abstact means we can not create an instance of this class. (just like pure virtual function in C++)
// All this function below must be definied in concreate classes.


public abstract class PlayerBaseState 
{
    protected PlayerStateMachine _ctx; // This is now inheited by each concreate state, because its protected
    protected PlayerStateFactory _factory; // This is now inheited by each concreate state, because its protected

    protected bool _isRootState = false;
    protected PlayerBaseState _currentSubState;
    protected PlayerBaseState _currentSuperState;
    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void FixedUpdateState();
    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    public abstract void InitializeSubStates();

 

    public void UpdateStates() // Can do something similar with exit states method
    {
        UpdateState();
        if(_currentSubState != null)
        {
            _currentSubState.UpdateStates();
        }
    }
    public void FixedUpdateStates()
    {
        FixedUpdateState();
        if (_currentSubState != null)
        {
            _currentSubState.FixedUpdateStates();
        }

    }


    protected void SwitchState(PlayerBaseState newState) // This is inherited aswell 
    {
        // Current State Exits State
        ExitState();

        // New State Enter State
        newState.EnterState();
        if (_isRootState)
        {
            _ctx.CurrentState = newState; // This is going to set a newState.
            
        }
        else if( _currentSuperState != null)
        {
            _currentSuperState.SetSubState(newState);
        }
    }

    protected void SetSuperState(PlayerBaseState newSuperState) 
    {
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState) 
    {
        _currentSubState = newSubState;

        newSubState.SetSuperState(this);
    }




}
