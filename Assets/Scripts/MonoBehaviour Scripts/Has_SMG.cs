using UnityEngine;
using System.Collections;

public class Has_SMG : MonoBehaviour {
	
	public Transform barrel;
	public GameObject bullet;
	public Transform explosion;
	public AudioClip enemyKilled;
    public AudioClip gunGoBoom;
    public float force = 50000;
	public bool hasWeapon;
	
	void FixedUpdate () 
	{
		if(hasWeapon == true)
		{
			if(Input.GetButtonDown ("Fire1"))
			{
				Debug.Log ("firing");
                //GameObject projectile = Instantiate(bullet, barrel.position, barrel.rotation) as GameObject;
                //print (projectile.name);
                //projectile.GetComponent<Rigidbody>().AddForce (barrel.forward * force);
                AudioSource.PlayClipAtPoint(gunGoBoom, barrel.position, 1.0F);
                float thickness = 1.0f; //<-- Desired thickness here.
				Vector3 origin = barrel.position /*+ new Vector3(transform.position.x,2.329061f,transform.position.z)*//*+ new Vector3(0,0.6f,-1.6f)*/;
				RaycastHit hit;
				Debug.DrawRay(origin, barrel.TransformDirection(Vector3.forward) * 1000, Color.green); // adapted from UA
				if(Physics.SphereCast(origin, thickness, barrel.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
					if(hit.collider.tag == "Enemy")
					{
						Instantiate(explosion, new Vector3(hit.transform.position.x, hit.transform.position.y + 10, hit.transform.position.z), hit.transform.rotation);
						AudioSource.PlayClipAtPoint (enemyKilled, hit.transform.position);
						Destroy(hit.transform.gameObject);
						print ("Gott'em Hah!");
					}
			}
		}
	}
}