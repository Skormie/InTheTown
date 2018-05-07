using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public Transform explosion;
	public AudioClip enemyKilled;
	public float height;
	public int health = 99;
	public int damage;

	void OnTriggerEnter(Collider boom) 
	{
		if(boom.gameObject.tag == "Enemy")
		{
			if(0 > (health - damage))
			{
				health = 0;
			}
			else
				health -= damage;

			if(health == 0)
			{
			Instantiate(explosion, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + height,
			                                   gameObject.transform.position.z), gameObject.transform.rotation);
			AudioSource.PlayClipAtPoint (enemyKilled, boom.transform.position);
			Destroy(gameObject);
			}
		}
	}
}
