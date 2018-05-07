using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform enemy;
	public float maxWait;
	public float minWait;
	public float randomSpawn;

	void Start()
	{
		randomSpawn = Mathf.Abs (Random.Range (minWait, maxWait));
	}

	void Update () 
	{
		randomSpawn -= Time.deltaTime;

		if(randomSpawn <= 0)
		{
			Network.Instantiate(enemy, transform.position, transform.rotation, 0);
			randomSpawn = Mathf.Abs(Random.Range(minWait,maxWait));
		}
	}
}
