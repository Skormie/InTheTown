using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown ("space") || Input.GetKeyDown ("joystick button 0"))
		{
			//Application.LoadLevel ("Test"); I guess this was "obsolete".
            SceneManager.LoadScene("Test");
		}
	}
}
