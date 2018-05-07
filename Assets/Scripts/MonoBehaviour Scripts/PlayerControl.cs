using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerControl : NetworkBehaviour
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public float rotSpeed = 2.0F;
	public bool isMine;

	Animator animator;
	
	void Start()
	{
        if (!isLocalPlayer)
            return;
        animator = GetComponent<Animator> ();
	}

	void Update() 
	{
        if (!isLocalPlayer)
            return;
        //Animation Code
        float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		animator.SetFloat ("VSpeed", v);
		animator.SetFloat ("HDirection",h);
		animator.SetFloat ("HSpeed", h);
		animator.SetFloat ("VDirection", v);

		//Character Control
		CharacterController controller = GetComponent<CharacterController>();
		//if(isMine) {
			if (controller.isGrounded) 
			{
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				if (Input.GetButton("Jump"))
					moveDirection.y = jumpSpeed;
				
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
	
			//Mouse Rotation X
			float mouseRotx = rotSpeed * Input.GetAxis ("Mouse X"); 
			transform.Rotate (0, mouseRotx, 0);

        //}
    }
}