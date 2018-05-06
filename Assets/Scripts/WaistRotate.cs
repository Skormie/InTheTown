using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WaistRotate : NetworkBehaviour
{

	public Transform bone;
	public float rotSpeed = 2.0F;
	public float currentRot;
	public float maxRot = 30;
	public float minRot = -80;

	void Start()
	{
        if (!isLocalPlayer)
            return;
        currentRot = bone.localRotation.z;
	}

	void LateUpdate () 
	{
        if (!isLocalPlayer)
            return;
        currentRot = currentRot - (rotSpeed * Input.GetAxis ("Mouse Y")); 
		currentRot = Mathf.Clamp (currentRot, minRot, maxRot);

		bone.localEulerAngles = new Vector3(bone.localRotation.x,bone.localRotation.y,currentRot);
	}
}
