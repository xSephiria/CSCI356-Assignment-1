using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject thePlayer;
    public Player player;
    GameObject PlayerUI;
    public HealthBarScript healthBar;

    private float HPBonus = 20;

   void Start()
    {
        PlayerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        healthBar = PlayerUI.GetComponentInChildren<HealthBarScript>(); 
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        player = thePlayer.GetComponent<Player>();
    }

    public void OnTriggerEnter(Collider inRange)
    {
        if(inRange.gameObject.tag == "Player")
        {
            if (player.currentHP < player.maxHP)
            {
                player.currentHP += HPBonus;
                healthBar.setHealth(player.currentHP);
                Destroy(gameObject);
            }
        }
    }
}
