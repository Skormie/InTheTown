using UnityEngine;
using System.Collections;

public class KillOverTime : MonoBehaviour {
	public float lifeTime = 1.0F;
	
	void Awake (){
		Destroy(gameObject, lifeTime);		
	}
}
