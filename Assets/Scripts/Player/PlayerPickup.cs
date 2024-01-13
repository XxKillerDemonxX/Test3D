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
            playerData.inventory[i] = Hand;
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
                for (int i = 0; i < playerData.inventory.Length; i++)
                {
                    if ((playerData.inventory[i] == null || playerData.inventory[i].layer == 3) && hit.collider.gameObject.GetComponent<Interactable>() != null)
                    {
                        playerData.inventory[i] = hit.collider.gameObject;
                        hit.collider.gameObject.transform.parent = Hand.transform;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.transform.rotation = Hand.transform.rotation;
                        hit.collider.gameObject.transform.position = Hand.transform.position;

                        break;
                    }
                }
            }

        }
    }
    void drop()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("Dropped");
            playerData.currentHeldItem.transform.parent = null;
            playerData.currentHeldItem.GetComponent<Rigidbody>().isKinematic = false;
            playerData.inventory[playerData.currentHeldItemSlot] = Hand;
            playerData.currentHeldItem = Hand;
        }
    }


}
