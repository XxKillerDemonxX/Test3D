using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public PlayerSO playerData;
    public GameObject Hand;
    // Start is called before the first frame update
    void Start()
    {
        playerData.Hand = Hand;
        for (int i = 0; i < 4; i++)
        {
            playerData.inventory[i] = playerData.Hand;
        }
    }

    // Update is called once per frame
    void Update()
    {
        pickUp();
        drop();
    }

    void pickUp()
    {
        Ray ray = Camera.main.ViewportPointToRay(playerData.screenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2))
        {
            //Debug.Log(hit.collider.name + " was hit!");
            if (Input.GetKeyUp(KeyCode.E))
            {
                GameObject GO = playerData.inventory[playerData.currentHeldItemSlot];
                //Rigidbody rb = hit.rigidbody;
                //GameObject temp = rb.gameObject;

                if (GO == playerData.Hand && hit.collider.gameObject.transform.root.gameObject.GetComponent<Interactable>() != null)
                {
                    Debug.Log("is working1");
                    GameObject item = hit.collider.gameObject.transform.root.gameObject;
                    playerData.inventory[playerData.currentHeldItemSlot] = item; //hit.collider.gameObject.transform.root.gameObject;
                    //Debug.Log(hit.collider.gameObject.transform.root.gameObject.name);
                    item.GetComponent<Interactable>().setPlayer(gameObject);
                    item.transform.parent = playerData.Hand.transform;
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.transform.rotation = playerData.Hand.transform.rotation;
                    item.transform.position = playerData.Hand.transform.position;
                }
                else
                {
                    for (int i = 0; i < playerData.inventory.Length; i++)
                    {
                        if ((playerData.inventory[i] == playerData.Hand && hit.collider.gameObject.transform.root.gameObject.GetComponent<Interactable>() != null))
                        {
                            Debug.Log("is working2");
                            GameObject item = hit.collider.gameObject.transform.root.gameObject;
                            playerData.inventory[i] = item;
                            item.GetComponent<Interactable>().setPlayer(gameObject);
                            item.transform.parent = playerData.Hand.transform;
                            item.GetComponent<Rigidbody>().isKinematic = true;
                            item.transform.rotation = playerData.Hand.transform.rotation;
                            item.transform.position = playerData.Hand.transform.position;

                            break;
                        }
                    }
                }
            }

        }
    }
    void drop()
    {
        if (Input.GetKeyUp(KeyCode.G) && (playerData.inventory[playerData.currentHeldItemSlot] != playerData.Hand))
        {
            Debug.Log("Dropped");
            playerData.currentHeldItem.transform.parent = null;
            playerData.currentHeldItem.GetComponent<Rigidbody>().isKinematic = false;
            playerData.currentHeldItem.GetComponent<Interactable>().resetPlayer();
            playerData.inventory[playerData.currentHeldItemSlot] = playerData.Hand;
            playerData.currentHeldItem = playerData.Hand;
        }
    }
    public PlayerSO getPlayerData()
    {
        return playerData;
    }
    public void resetHand()
    {
        playerData.inventory[playerData.currentHeldItemSlot] = playerData.Hand;
        playerData.currentHeldItem = playerData.Hand;
        
    }


}
