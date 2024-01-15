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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2))
        {
            //Debug.Log(hit.collider.name + " was hit!");
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (playerData.inventory[playerData.currentHeldItemSlot] == playerData.Hand && hit.collider.gameObject.GetComponent<Interactable>() != null)
                {
                    playerData.inventory[playerData.currentHeldItemSlot] = hit.collider.gameObject;
                    hit.collider.gameObject.transform.parent = playerData.Hand.transform;
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    hit.collider.gameObject.transform.rotation = playerData.Hand.transform.rotation;
                    hit.collider.gameObject.transform.position = playerData.Hand.transform.position;
                }
                else
                {
                    for (int i = 0; i < playerData.inventory.Length; i++)
                    {
                        if ((playerData.inventory[i] == playerData.Hand || playerData.inventory[i].layer == 3) && hit.collider.gameObject.GetComponent<Interactable>() != null)
                        {
                            playerData.inventory[i] = hit.collider.gameObject;
                            hit.collider.gameObject.transform.parent = playerData.Hand.transform;
                            hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            hit.collider.gameObject.transform.rotation = playerData.Hand.transform.rotation;
                            hit.collider.gameObject.transform.position = playerData.Hand.transform.position;

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
            playerData.inventory[playerData.currentHeldItemSlot] = playerData.Hand;
            playerData.currentHeldItem = playerData.Hand;
        }
    }


}
