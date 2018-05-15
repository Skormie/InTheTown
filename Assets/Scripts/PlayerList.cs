using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;

public class PlayerList : NetworkManager
{

    private int playerCount = 0;

    [SerializeField] public List<GameObject> players = new List<GameObject>();
    //[SerializeField] public Dictionary<short, GameObject> players = new Dictionary<short, GameObject>();
    //[SerializeField] public Hashtable players = new Hashtable();
    //[SerializeField] public GameObject[] players = new GameObject[4];



    public override void OnServerConnect(NetworkConnection connection)
    {
        Debug.Log("Player " + playerCount + " connected from " + connection.address + ":" + connection.hostId);
    //    foreach (var player in connection.playerControllers)
    //    {
    //        //players.Add(player.gameObject);
    //        Debug.Log(player.IsValid);
    //        players[playerCount] = player.gameObject;
    //    }
        playerCount++;
    }

    //Detect when a client disconnects from the Server
    //public override void OnServerDisconnect(NetworkConnection connection)
    //{
    //    //Change the text to show the loss of connection
    //    foreach (var player in connection.playerControllers)
    //    {
    //        //players.Remove(player.gameObject);
    //        //foreach (var user in players)
    //        //{

    //        //}
    //    }
    //}

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        //player.GetComponent<Renderer>().color = Color.red;
        //players.Add(conn.connectionId, player);
        players.Add(player);
        Debug.Log("PID: " + playerControllerId + ", CID: " + conn.connectionId + ", NETID: " + player.GetComponent<NetworkIdentity>().netId + ".");
        //player.GetComponent<NetworkIdentity>().netId
        //players[playerControllerId] = player;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}