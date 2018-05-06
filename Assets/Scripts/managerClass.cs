using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class managerClass : MonoBehaviour
{
	public Transform GameManager;

/*
    public GameObject playerPrefab;

    void OnConnectedToServer()
    {
        Debug.Log("OnPlayerConnected");
        var player = Network.Instantiate(playerPrefab, GameObject.FindWithTag("NetworkSpawn").transform.position, Quaternion.identity, 0);
        Debug.Log("OnPlayerConnected");
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    
        // called when a client connects 
        public override void OnServerConnect(NetworkConnection conn) {  }
    

    
        // called when a client disconnects
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            NetworkServer.DestroyPlayersForConnection(conn);
        }
    

    
        // called when a client is ready
        public override void OnServerReady(NetworkConnection conn)
        {
            NetworkServer.SetClientReady(conn);
        }
    

    // called when a new player is added for a client
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        var player = (GameObject)GameObject.Instantiate(playerPrefab, GetStartPosition().position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    
        // called when a player is removed for a client
        public override void OnServerRemovePlayer(NetworkConnection conn, short playerControllerId)
        {
            PlayerController player;
            if (conn.GetPlayer(playerControllerId, out player))
            {
                if (player.NetworkIdentity != null && player.NetworkIdentity.gameObject != null)
                    NetworkServer.Destroy(player.NetworkIdentity.gameObject);
            }
        }
   

    
        // called when a network error occurs
        public override void OnServerError(NetworkConnection conn, int errorCode) { }
    

*/}