using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Inventory")]
public class ScriptableInventory : ScriptableObject {

    [SerializeField]
    int currentWeapon;

    [SerializeField]
    ScriptableGun[] guns;
    public ScriptableGun[] Guns { get { return guns; } }

    public ScriptableGun RandomGun { get { return GetRandom(); } }

    public ScriptableGun GetRandom()
    {
        return guns[Random.Range(0, guns.Length)];
    }

    public ScriptableGun GetNextUp()
    {
        if(currentWeapon < guns.Length)
        {
            currentWeapon++;
        }
        else
        {
            currentWeapon = 0;
        }
        return guns[currentWeapon];
    }

    public ScriptableGun GetNextDown()
    {
        if (currentWeapon > 0)
        {
            currentWeapon--;
        }
        else
        {
            currentWeapon = guns.Length;
        }
        return guns[currentWeapon];
    }

}
