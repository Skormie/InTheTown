using UnityEngine;
using System.Collections;

public class EnemyKill : MonoBehaviour {

	//public HUD points;
	public Transform explosion;
	public AudioClip enemyKilled;
	public float height;

	void OnTriggerEnter(Collider boom) 
	{
	/*	if(boom.gameObject.tag == "Bullet")
		{
			//points.score = points.score + 1;
			Instantiate(explosion, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + height,
			                                   gameObject.transform.position.z), gameObject.transform.rotation);
			AudioSource.PlayClipAtPoint (enemyKilled, boom.transform.position);
			Destroy(gameObject);
		}*/

		if(boom.gameObject.tag == "Player")
		{
			Instantiate(explosion, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + height,
			                                   gameObject.transform.position.z), gameObject.transform.rotation);
			AudioSource.PlayClipAtPoint (enemyKilled, boom.transform.position);
			Destroy(gameObject);
		}
	}
}
