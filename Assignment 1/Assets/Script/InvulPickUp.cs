using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulPickUp : MonoBehaviour
{
    public Player player;
    public void OnTriggerEnter(Collider inRange)
    {
        if (inRange.gameObject.tag == "Player")
        {
            player.isInvulnarable = true;
            Destroy(gameObject);
        }
    }
}
