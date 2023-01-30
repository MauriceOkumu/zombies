using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
	[Header("Zombie behaviour and movement")]
	[Tooltip("Zombie will move and attack this target")]
	[SerializeField] Transform target;
	[Tooltip("The chase range of the zombie")]
	[SerializeField] float chaseRange = 10f;
	[Tooltip("The distance to the target")]
	[SerializeField] float targetDistance = Mathf.Infinity;
	 UnityEngine.AI.NavMeshAgent agent;
	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		targetDistance = Vector3.Distance(target.position, transform.position);
		
		//See if the player is in attack range
		if(targetDistance <= chaseRange) agent.SetDestination(target.position);
	}
	
}
