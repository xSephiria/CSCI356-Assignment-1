using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Entry : MonoBehaviour
{
    public GameObject Player;
    public int P_ID;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Player.gameObject.transform.position = Target.gameObject.transform.position + new Vector3(0, 3, 0);
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Portals_Exit");
            for(int i = 0; i < targets.Length; i++)
            {
                if(targets[i].GetComponent<Portal_Exit>().P_EID == P_ID)
                {
                    Player.gameObject.transform.position = targets[i].gameObject.transform.position + new Vector3(0, 3, 0);
                }
            }
            
        }
    }
}
