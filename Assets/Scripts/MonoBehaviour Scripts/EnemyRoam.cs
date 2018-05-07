using UnityEngine;
using System.Collections;

public class EnemyRoam : MonoBehaviour 
{

	public Transform target;
	UnityEngine.AI.NavMeshAgent agent;

	void Start () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		Transform player = GameObject.FindWithTag ("Player").transform;
		target = player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target)
			agent.SetDestination (target.position);
	}
}
