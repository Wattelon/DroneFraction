using UnityEngine;

public class UnloadState : BaseState
{
    private float _unloadTime;
    
    public override void EnterState()
    {
        _context.NavMeshAgent.avoidancePriority = Random.Range(20, 30);
        _context.ParticleSystem.Play();
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
        _context.ParticleSystem.Stop();
        _context.TargetBase.UnloadingDrone = null;
        _context.TargetBase = null;
        _unloadTime = 0f;
    }
}
