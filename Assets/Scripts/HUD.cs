using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HUD : MonoBehaviour 
{
	
	public Text healthText;
	public PlayerHealth health;
    public GameObject player;
	
	void Start () 
	{
		healthText = GetComponent<Text>();
		//GameObject player = GameObject.FindWithTag ("Player");
		health = player.GetComponent<PlayerHealth>();
	}
	
	void Update () 
	{
		//if(isServer)
			healthText.text = "" + (health.health);
	}
}
