using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.XR;
[CreateAssetMenu(fileName = "New Player", menuName = "ScriptableObjects/Player")]
public class PlayerSO : ScriptableObject
{
    public int hp = 100;
    public bool alive = true;

    public GameObject Hand;



    public GameObject[] inventory = new GameObject[4];

    public int currentHeldItemSlot = 0;
    public GameObject currentHeldItem;
    public Ray ray;

}
