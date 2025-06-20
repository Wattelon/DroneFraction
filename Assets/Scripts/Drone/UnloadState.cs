using UnityEngine;

public class UnloadState : BaseState
{
    private float _unloadTime;
    
    public override void EnterState()
    {
        _context.NavMeshAgent.avoidancePriority = Random.Range(30, 40);
    }

    public override void UpdateState()
    {
        _unloadTime += Time.deltaTime;
        if (_unloadTime >= 2f)
        {
            _context.Unload();
            _context.SwitchState(_context.SearchState);
        }
    }

    public override void ExitState()
    {
        _context.TargetBase = null;
        _unloadTime = 0f;
    }
}
