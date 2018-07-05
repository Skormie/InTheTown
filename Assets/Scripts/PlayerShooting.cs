using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[NetworkSettings(sendInterval = 0.01f)]
public class PlayerShooting : NetworkBehaviour {

    [SerializeField] float shotCooldown = .3f;
    [SerializeField] Transform firePosition;
    [SerializeField] ShotEffectsManager shotEffects;
    [SerializeField] Vector3 hit_pos;
    [SerializeField] public ScriptablePlayerListRuntimeSet playerList;
    [SerializeField] ScriptableGun currentWeapon;

    [SyncVar (hook = "OnScoreChanged")] int score;

    float ellapsedTime;
    bool canShoot;

	// Use this for initialization
	void Start () {
        shotEffects.Initialize();
        playerList.Add(transform.gameObject);
        if (isLocalPlayer)
        {
            canShoot = true;
        }
	}

    [ServerCallback] //Only run on the server.
    private void OnEnable()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        if (!canShoot) return;

        ellapsedTime += Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && ellapsedTime > shotCooldown)
        {
            ellapsedTime = 0f;
            RaycastHit hit;

            //Ask server to shoot.
           /// CmdFireShot(firePosition.position, firePosition.forward);

            Ray ray = new Ray(firePosition.position, firePosition.forward);
            Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 1f);
            bool result = Physics.Raycast(ray, out hit, 50f);

            if (result)
            {
                hit_pos = hit.transform.position;
                NewPlayerHealth enemy = hit.transform.GetComponent<NewPlayerHealth>();
                if (enemy != null)
                {
                    CmdFireShot(firePosition.position, firePosition.forward, hit_pos, hit.transform.gameObject.GetComponent<NetworkIdentity>().netId);
                    return;
                }
            }
            CmdFireMissedShot(firePosition.position, firePosition.forward);
        }
	}

    [Command] //This is run on the server.
    void CmdFireShot(Vector3 origin, Vector3 direction, Vector3 hit_pos, NetworkInstanceId netid)
    {
        Debug.Log("Player Count is... "+playerList.players.Count);
        //Debug.Log("origin: "+ origin+", direction: "+ direction+ ", hit_pos: "+ hit_pos);
        //Debug.Log("Size of player list " + manager.GetComponent<PlayerList>().players.Count);
        ////Debug.Log("Size of player list " + PlayerList.singleton.GetComponent<PlayerList>().players.Count +", NETID: "+netid+", ");
        //GameObject closestObject = null;
        GameObject player = playerList.GetPlayer(netid);

        Debug.Log("Distance of " + Vector3.Distance(hit_pos, player.transform.position) + ".");
        if (Vector3.Distance(hit_pos, player.transform.position) < 3)
        {
            //health stuff
            NewPlayerHealth enemy = playerList.GetPlayer(netid).transform.GetComponent<NewPlayerHealth>();

            if (enemy != null)
            {
                bool wasKillShot = enemy.TakeDamage();

                if (wasKillShot)
                    score++;
            }
        }

        RaycastHit hit;

        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 1f);

        ////50f How far the gun shoots.
        ////Save guns in ScriptableObjects.
        bool result = Physics.Raycast(ray, out hit, 50f);

        RpcProcessShotEffects(result, hit.point, hit.normal);
    }

    [Command] //This is run on the server. If the client missed their shot.
    void CmdFireMissedShot(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;

        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 1f);

        ////50f How far the gun shoots.
        ////Save guns in ScriptableObjects.
        bool result = Physics.Raycast(ray, out hit, 50f);

        RpcProcessShotEffects(result, hit.point, hit.normal);
    }

    [ClientRpc] //Server tells all the clients to do something.
    void RpcProcessShotEffects(bool playImpact, Vector3 point, Vector3 normal)
    {
        shotEffects.PlayShotEffects();

        if (playImpact)
            shotEffects.PlayImpactEffect(point, normal);
    }

    void OnScoreChanged(int value)
    {
        score = value;
        if (isLocalPlayer)
        {
            PlayerCanvas.canvas.SetKills(value);
        }
    }
}

