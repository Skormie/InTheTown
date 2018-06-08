using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;

	// Use this for initialization
	void Start () {
        SelectWeapon();
    }

	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        Cursor.lockState = CursorLockMode.None;     // set to default default
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            selectedWeapon = (selectedWeapon + 1) % (transform.childCount);
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            selectedWeapon = Mathf.Abs((selectedWeapon - 1) % transform.childCount);

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
