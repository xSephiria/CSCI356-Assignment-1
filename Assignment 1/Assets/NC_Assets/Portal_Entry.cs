using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Entry : MonoBehaviour
{

    public int P_ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject[] target_to_go = GameObject.FindGameObjectsWithTag("Portals_Exit");
            Debug.Log(target_to_go.Length);
            for (int i = 0; i < target_to_go.Length; i++)
            {
                if (target_to_go[i].GetComponent<Portal_Exit>().P_EID == P_ID)
                {
                    Transform PlaterTrf;
                    PlaterTrf = GameObject.FindGameObjectWithTag("Player").transform;
                    PlaterTrf = target_to_go[i].gameObject.transform;
                }

            }
        }
    }
}
