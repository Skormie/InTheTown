using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewPlayerHealth : NetworkBehaviour {

    [SerializeField] int maxHealth = 3;

    Player player;
    int health;

    //Awake happens before knowing local player.
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    [ServerCallback] // This code will only exist on the server.
    private void OnEnable()
    {
        health = maxHealth;
    }

    [Server] // Only server allowed to run method.
    public bool TakeDamage()
    {
        bool died = false;

        if(health <= 0) //You're already dead.
        {
            return died;
        }

        health--;
        Debug.Log("Player HP "+health+".");
        died = health <= 0; //Boolean logic.

        RpcTakeDamage(died);

        return died;
    }

    [ClientRpc] //All clients process taking damage.
    void RpcTakeDamage(bool died)
    {
        if (died)
        {
            Debug.Log("The player is dead.");
            player.Die();
        }
    }
}
