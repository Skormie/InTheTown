using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewPlayerHealth : NetworkBehaviour {

    [SerializeField] int maxHealth = 10;

    [SyncVar (hook = "OnHealthChanged")] int health; //When the value changes it will be shared with all clients. Only the server can set the value of a SyncVar.

    Player player;


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

    [ServerCallback]
    private void Start()
    {
        health = maxHealth;
        //OnEnable();
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
        if (isLocalPlayer)
        {
            PlayerCanvas.canvas.FlashDamageEffect();
        }

        if (died)
        {
            Debug.Log("The player is dead.");
            player.Die();
        }
    }

    void OnHealthChanged(int value)
    {
        health = value;
        if (isLocalPlayer)
        {
            PlayerCanvas.canvas.SetHealth(value);
        }
    }
}
