using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HoldWeapon : NetworkBehaviour {
	
	public Transform barrel;
	public GameObject bullet;
    public Renderer r;

    /*
    public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player")
		{
//player_enable_weapon = other.GetComponent<Has_SMG>();
//other.GetComponent<Has_SMG>().hasWeapon = true;
			Destroy (gameObject);
			Renderer[] renderers = other.GetComponentsInChildren<Renderer>();
			foreach (Renderer r in renderers) {
                print(r.name); //debug
				if(r.tag == "SMG") {
                    r.enabled = true;
//r.gameObject.layer = 14;
                    r.gameObject.GetComponent<Has_SMG>().hasWeapon = true;
				}
			}
//hasWeapon = true;
		}
	}
    */

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Renderer[] renderers = other.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                print(r.name+" "+ r.tag); //debug
                if (r.tag == "SMG")
                {
                    r.enabled = true;
                    r.gameObject.GetComponent<Has_SMG>().hasWeapon = true;
                }
            }
        }
    }
}
