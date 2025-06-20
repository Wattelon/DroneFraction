using System.Linq;
using UnityEngine;

public class RetrieveState : BaseState
{
    public override void EnterState()
    {
        _context.NavMeshAgent.avoidancePriority = Random.Range(40, 50);
        _context.TargetBase = FindClosestBase();
        _context.NavMeshAgent.SetDestination(_context.TargetBase.transform.position);
    }

    public override void UpdateState()
    {
        if (_context.TargetBase.UnloadingDrone is null)
        {
            _context.TargetBase.UnloadingDrone = _context;
            _context.NavMeshAgent.avoidancePriority = Random.Range(30, 40);
        }
        if (_context.NavMeshAgent.remainingDistance <= _context.NavMeshAgent.stoppingDistance)
        {
            _context.SwitchState(_context.UnloadState);
        }
    }

    public override void ExitState()
    {
        
    }

    private Base FindClosestBase()
    {
        return Object.FindObjectsByType<Base>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Where(b => b.Faction == _context.Faction)
            .Aggregate((closestBase, currentBase) =>
                closestBase is null || (currentBase.transform.position - _context.transform.position).sqrMagnitude < (closestBase.transform.position - _context.transform.position).sqrMagnitude ? currentBase : closestBase);
    }
}
