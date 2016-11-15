using UnityEngine;
using System.Collections;

public StatePatternEnemy : Monobehaviour
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offset = (0..5f, 0);
	public MeshRenderer meshRenderFlag;
	
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public navMeshAgent navMeshAgent;
	
	private void Awake()
	{
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
		navMeshAgent = GetComponent<navMeshAgent>();
	}
	
	void Start()
	{
		currentState = patrolState;
	}
	
	void Update()
	{
		currentState.UpdateState();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter(other);
	}
	
}