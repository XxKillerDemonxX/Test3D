using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerSO playerData;
    public GameObject Hand;
    void Start()
    {
        
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
            if (playerData.currentHeldItem != playerData.inventory[i] && playerData.inventory[i] != Hand)
            {
                playerData.inventory[i].SetActive(false);
            }
        }
        playerData.currentHeldItem.SetActive(true);
    }
}
