﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Player/Gun")]
public class ScriptableGun : ScriptableObject {

    public new string name;
    public string description;

    public GameObject gun;

    //public Transform firePosition;

    public Vector3 firePosition;

    public int spreadY;
    public int spreadZ;

    public float coolDown;
}
