﻿using System.Collections;
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
