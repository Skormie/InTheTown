using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeThrow : MonoBehaviour {

    public float throwForce = 40f;
    public GameObject granadePrefab;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) //Right Mouse Button.
        {
            ThrowGranade();
        }
	}

    void ThrowGranade()
    {
        GameObject granade = Instantiate(granadePrefab, transform.position, transform.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
