using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceGrenade : MonoBehaviour {

    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

	// Use this for initialization
	void Start () {
        countdown = delay;
	}

	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
            Explode();
	}

    void Explode()
    {
        hasExploded = true;
        Debug.Log("BOOM");

        //Show Effect
        Destroy( Instantiate(explosionEffect, transform.position, transform.rotation), 1f);

        // Get nearby Objects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            // Add force
            NewPlayerHealth enemy = nearbyObject.GetComponent<NewPlayerHealth>();
            if(enemy != null)
            {
                bool wasKillShot = enemy.TakeDamage();

                //if (wasKillShot)
                    //score++;
            }
        }
        // Add force
        Collider[] collidersToAddForce = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in collidersToAddForce)
        {
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }
        // Damage

        // Remove Granade
        Destroy(gameObject);
    }
}
