using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	private Transform target;

	void Start()
	{
		target = GameObject.FindWithTag ("MainCamera").transform;
	}

	void Update () 
	{
		transform.LookAt (target);
	}
}
