using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScriptablePlayerList<T> : ScriptableObject {

    //public List<T> players;

    //public Hashtable players;

    //public GameObject[] players;

    [SerializeField] public Dictionary<NetworkInstanceId, GameObject> players = new Dictionary<NetworkInstanceId, GameObject>();

    public void Add(T t)
    {
        if (/*!players.Contains(t) &&*/ t is GameObject)
        {
            GameObject g = t as GameObject;
            //players.Add(g.GetComponent<NetworkIdentity>().netId, t);
            players[g.GetComponent<NetworkIdentity>().netId] = g;
        }
    }

    public void Remove(T t)
    {
        //if (players.Contains(t))
        //    players.Remove(t);
        if (t is GameObject)
        {
            GameObject g = t as GameObject;
            players.Remove(g.GetComponent<NetworkIdentity>().netId);
        }
    }

    public GameObject GetPlayer(NetworkInstanceId netid)
    {
        return players[netid];
    }

    private void OnEnable()
    {
        players.Clear();
    }
}
