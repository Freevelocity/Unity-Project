// This creates the concreate state from within the context.
// Start is called before the first frame update

// Constructor Function is called when we create a new Instance of this class 
public class PlayerStateFactory
{
    PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext; // Sets _context to the currentContext that gets passed in.
    }

    // These return a new Instance of their respective concreate States,
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this); 
    }

    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context,this);
    }
    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_context, this);
    }
    public PlayerBaseState Grounded()
    {
        return new PlayerGroundedState(_context, this);
    }

}
