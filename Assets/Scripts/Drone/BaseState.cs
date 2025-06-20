public abstract class BaseState
{
    private protected Drone _context;

    public void Initialize(Drone context)
    {
        _context ??= context;
    }
    
    public abstract void EnterState();
    
    public abstract void UpdateState();
    
    public abstract void ExitState();
}
