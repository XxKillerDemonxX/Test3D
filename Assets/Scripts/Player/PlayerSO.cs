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
    public int maxStamina = 100;
    public int currentStamina = 100;

    public GameObject Hand;



    public GameObject[] inventory = new GameObject[4];
    public int currentHeldItemSlot = 0;
    public GameObject currentHeldItem;

    public Ray gunRay;
    public Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
    public Camera camera;


    public float walkingSpeed = 3f;
    public float runningSpeed = 5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 75.0f;


}
