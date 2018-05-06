using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworking : NetworkBehaviour {

    public static void ChangeLayers(GameObject go, string name)
    {
          ChangeLayers(go, LayerMask.NameToLayer(name));
    }

    public static void ChangeLayers(GameObject go, int layer)
    {
        if (go.layer != 14)
            go.layer = layer;
        foreach (Transform child in go.transform)
        {
            ChangeLayers(child.gameObject, layer);
        }
    }

    // Use this for initialization
    void Start () {

        if (isLocalPlayer) {
            transform.GetComponent<PlayerControl>().isMine = true;
            //gameObject.layer = int.Parse("" + netId) + 10;
            //ChangeLayers(gameObject, "Player "+netId);
            //ChangeLayers(gameObject, "Player 1");
            //gameObject.layer = LayerMask.NameToLayer("Player " + netId);
            //print(transform.GetChild(0).name); //Raptor Debug
            //transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Player " + netId);
            transform.GetChild(0).gameObject.layer = 8;
        } else {
            //transform.GetComponent<Camera>().enabled = false;
            transform.GetComponentInChildren<Camera>().enabled = false;
            transform.GetComponentInChildren<AudioListener>().enabled = false;
            transform.GetComponentInChildren<PlayerControl>().isMine = false;
        }
	
	}

    // Update is called once per frame
    void Update () {
	
		if (isLocalPlayer){
			transform.GetComponent<NetworkAnimator>().GetParameterAutoSend(1);  
			transform.GetComponent<NetworkAnimator>().GetParameterAutoSend(0);
			//transform.GetComponent(NetworkAnimator).GetParameterAutoSend(6);
		}
		
		transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(1,true);  
		transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
		transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(6,true);
		transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(3,true);
		transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(4,true);

    }

    void OnGUI ()
    {
        if (isLocalPlayer)
        {
            GUI.TextArea(new Rect(10, 700, Screen.width - 10, Screen.height - 10), "Hello World! \r\nNetwork ID: "+netId+"\r\nController ID: "+playerControllerId);
        }
    }

}
