using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerSO playerData;
    void Start()
    {
        playerData.currentHeldItem = playerData.Hand;
    }

    // Update is called once per frame
    void Update()
    {
        toggleItemVisibility();
    }
    void toggleItemVisibility()
    {
        for (int i = 0; i < 4; i ++)
        {
            if (playerData.currentHeldItem != playerData.inventory[i] && playerData.inventory[i] != playerData.Hand)
            {
                playerData.inventory[i].SetActive(false);
            }
        }
        playerData.currentHeldItem.SetActive(true);
        Interactable d = playerData.currentHeldItem.GetComponent<Interactable>();

        if (playerData.currentHeldItem != playerData.Hand)
            playerData.currentHeldItem.transform.localRotation = Quaternion.Euler(new Vector3(d.rotationX, d.rotationY, d.rotationZ));
    }
}
