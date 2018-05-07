using UnityEngine;
using System.Collections;

public class RaptorControl : MonoBehaviour {

	public float speed = 10.0F;
	private Vector3 moveDirection = Vector3.zero; 
	public string horizontal = "";
	public string vertical = "";  
	static float speedIncrease = 0F;

	public float moveSpeed = 4.0F;
	public float rotSpeed = 2.0F;

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}
	
	void Awake () 
	{
		speedIncrease = 0;
	}
	
	
	void Update () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		animator.SetFloat ("VSpeed", v);
		animator.SetFloat ("HDirection",h);
		animator.SetFloat ("HSpeed", h);
		animator.SetFloat ("VDirection", v);

		moveDirection = new Vector3 (Input.GetAxis (horizontal), 0, Input.GetAxis (vertical));  
		moveDirection = transform.TransformDirection (moveDirection);            
		moveDirection = moveDirection * (speed + speedIncrease);
		CharacterController controller = GetComponent<CharacterController> ();           
		controller.Move (moveDirection * Time.deltaTime); 

		float mouseRot = rotSpeed * Input.GetAxis ("Mouse X"); 
		transform.Rotate (0, mouseRot, 0);
	}
}
