using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooting : NetworkBehaviour {

    [SerializeField] float shotCooldown = .3f;
    [SerializeField] Transform firePosition;
    [SerializeField] ShotEffectsManager shotEffects;

    [SyncVar (hook = "OnScoreChanged")] int score;

    float ellapsedTime;
    bool canShoot;

	// Use this for initialization
	void Start () {
        shotEffects.Initialize();

        if (isLocalPlayer)
            canShoot = true;
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

            //Ask server to shoot.
            CmdFireShot(firePosition.position, firePosition.forward);
        }
	}

    [Command] //This is run on the server.
    void CmdFireShot(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;


        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 1f);

        //50f How far the gun shoots.
        //Save guns in ScriptableObjects.
        bool result = Physics.Raycast(ray, out hit, 50f);

        if (result)
        {
            //health stuff
            NewPlayerHealth enemy = hit.transform.GetComponent<NewPlayerHealth>();

            if(enemy != null)
            {
                bool wasKillShot = enemy.TakeDamage();

                if (wasKillShot)
                    score++;
            }
        }

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

