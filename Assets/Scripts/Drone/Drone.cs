using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    [SerializeField] private Faction faction;
    [SerializeField] private int carriedResources;

    private BaseState _currentState;
    
    public Faction Faction => faction;
    
    public NavMeshAgent NavMeshAgent { get; private set; }
    public SearchState SearchState { get; } = new();
    public HarvestState HarvestState { get; } = new();
    public RetrieveState RetrieveState { get; } = new();
    public UnloadState UnloadState { get; } = new();
    
    public Resource TargetResource;
    public Base TargetBase;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        SearchState.Initialize(this);
        HarvestState.Initialize(this);
        RetrieveState.Initialize(this);
        UnloadState.Initialize(this);
    }

    private void Start()
    {
        _currentState = SearchState;
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void SwitchState(BaseState state)
    {
        _currentState.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }

    public void Harvest()
    {
        carriedResources = TargetResource.Collect();
    }

    public void Unload()
    {
        TargetBase.Resources += carriedResources;
        carriedResources = 0;
    }
}
