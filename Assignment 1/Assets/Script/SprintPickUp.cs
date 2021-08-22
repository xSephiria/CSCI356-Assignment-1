using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPickUp : MonoBehaviour
{
    public GameObject thePlayer;
    public Player player;

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        player = thePlayer.GetComponent<Player>();
    }

    public void OnTriggerEnter(Collider inRange)
    {
        if (inRange.gameObject.tag == "Player")
        {
            player.isUnlimitedStamina = true;
            Destroy(gameObject);
        }
    }
}
