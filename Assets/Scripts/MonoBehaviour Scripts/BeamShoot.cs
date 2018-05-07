using UnityEngine;
using System.Collections;

public class BeamShoot : MonoBehaviour {
	public Renderer rend;
	public Collider coll;
	public float fire = 3.0F;
	public float duration = 1.0F;

	public AudioSource beam;

	[HideInInspector]
	public float savedTime;
	[HideInInspector]
	public float savedDuration;
	[HideInInspector]
	public bool isFiring = false;

	void Start () {
		rend.enabled = false;
		coll.enabled = false;
		savedTime = fire;
		savedDuration = duration;
	}

	void Update () {
		fire -= Time.deltaTime;

		if((Input.GetKeyDown ("space") || Input.GetKeyDown ("joystick button 0")) && fire <= 0)
		{
			rend.enabled = true;
			coll.enabled = true;
			isFiring = true;
			beam.Play ();
		}
		if(isFiring == true){
			duration -= Time.deltaTime;
			if(duration <= 0){
				GetComponent<AudioSource>().Stop ();
				rend.enabled = false;
				coll.enabled = false;
				isFiring = false;
				duration = savedDuration;
				fire = savedTime;
				beam.Stop ();
			}
		}
	}
}
