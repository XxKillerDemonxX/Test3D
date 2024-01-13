using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Action : MonoBehaviour
{
    public PlayerSO playerData;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            playerData.currentHeldItemSlot = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            playerData.currentHeldItemSlot = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            playerData.currentHeldItemSlot = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            playerData.currentHeldItemSlot = 3;
        }

        playerData.currentHeldItem = playerData.inventory[playerData.currentHeldItemSlot];

        if (Input.GetKeyUp(KeyCode.Mouse0) && playerData.currentHeldItem != null)
        {
            Interactable item = playerData.currentHeldItem.GetComponent<Interactable>();
            if (item != null)
                item.interactable();
        }



    }
    private void OnApplicationQuit()
    {
        Array.Clear(playerData.inventory, 0, 4);
    }
}
