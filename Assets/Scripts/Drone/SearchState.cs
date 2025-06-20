using System.Linq;
using UnityEngine;

public class SearchState : BaseState
{
    public override void EnterState()
    {
        _context.NavMeshAgent.avoidancePriority = Random.Range(50, 60);
    }

    public override void UpdateState()
    {
        if (_context.TargetResource is null || !_context.TargetResource.isActiveAndEnabled || _context.TargetResource.CollectingDrone != _context)
        {
            _context.TargetResource = FindClosestResource();
            _context.TargetResource.CollectingDrone = _context;
            _context.NavMeshAgent.SetDestination(_context.TargetResource.transform.position);
            _context.NavMeshAgent.avoidancePriority = Random.Range(40, 50);
        }
        else if (_context.NavMeshAgent.remainingDistance < _context.NavMeshAgent.stoppingDistance)
        {
            _context.SwitchState(_context.HarvestState);
        }
    }

    public override void ExitState()
    {
        
    }

    private Resource FindClosestResource()
    {
        return Object.FindObjectsByType<Resource>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)
            .Aggregate((closestResource, currentResource) =>
                !currentResource.CollectingDrone && (closestResource is null || (currentResource.transform.position - _context.transform.position).sqrMagnitude < (closestResource.transform.position - _context.transform.position).sqrMagnitude) ? currentResource : closestResource);
    }
}
