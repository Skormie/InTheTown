using UnityEngine;
using System.Collections;

public class CrossHairs : MonoBehaviour {

	public Texture2D crosshairTexture;
	public float crosshairScale = 1;
	public float x_offset;
	public float y_offset;
	
	void OnGUI()
	{
		if(Time.timeScale != 0)
		{
			if(crosshairTexture!=null)
				GUI.DrawTexture(
					new Rect(
						(Screen.width-crosshairTexture.width*crosshairScale)/2*x_offset,
						(Screen.height-crosshairTexture.height*crosshairScale)/2*y_offset,
						crosshairTexture.width*crosshairScale,
						crosshairTexture.height*crosshairScale
					),
				crosshairTexture);
			else
				Debug.Log("No crosshair texture set in the Inspector");
		}
	}
	
}
