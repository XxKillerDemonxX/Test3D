using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPackScript : Interactable
{
    // Update is called once per frame
    double time = 0;
    int hpHeal = 50;
    Boolean beingUsed = false;
    new GameObject player;
    PlayerSO playerData;
    PlayerPickup playerPickup;
    void Update()
    {
        
    }
    public override void interactable()
    {
        
    }
    public override void setPlayer(GameObject player)
    {
        this.player = player;
        playerPickup = player.GetComponent<PlayerPickup>();
        playerData = playerPickup.getPlayerData();
    }
    public override void resetPlayer()
    {
        player = null;
        playerPickup = null;
        playerData = null;
    }
    public override void holdInteractable()
    {

        if (beingUsed == false)
        {
            time = 0;
        }  
        time += Time.deltaTime;
        Debug.Log(time);
        beingUsed = true;
        if (time >= 5)
        {
            playerData.hp += hpHeal;
            playerPickup.resetHand();
            Destroy(gameObject);
        }
    }
    public override void endHoldInteractable()
    {
        beingUsed = false;
    }
}
