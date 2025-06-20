using UnityEngine;

public class HarvestState : BaseState
{
    private float _harvestTime;
    
    public override void EnterState()
    {
        _context.NavMeshAgent.avoidancePriority = Random.Range(30, 40);
    }

    public override void UpdateState()
    {
        _harvestTime += Time.deltaTime;
        if (_harvestTime >= 2f)
        {
            _context.Harvest();
            _context.SwitchState(_context.RetrieveState);
        }
    }

    public override void ExitState()
    {
        _context.TargetResource = null;
        _harvestTime = 0f;
    }
}
