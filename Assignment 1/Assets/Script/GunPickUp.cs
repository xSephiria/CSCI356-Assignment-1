using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Gun gun;
    public Rigidbody rb;
    public CapsuleCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    private float Dtimer = 3f; 

    public bool isEquiped;
    public static bool alrdyEquiped;

    public void PickUp()
    {
        isEquiped = true;
        alrdyEquiped = true;

        //make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make rigidbody kinamatic and Collider a trigger 
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable script
        gun.enabled = true;
        gun.ammo = 30;
        gun.crossHair.SetActive(true);
    }

    public void Drop()
    {
        isEquiped = false;
        alrdyEquiped = false;

        //set parent null
        transform.SetParent(null);

        //Make rigidbody kinamatic and boxCollider a trigger 
        rb.isKinematic = false;
        coll.isTrigger = false;

        //gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //add force
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        //add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        rb.useGravity = true;

        //enable script 
        gun.enabled = false;
        gun.ammo = 0;
        gun.ammoDisplay.text = "Ammo: " + gun.ammo.ToString();
        gun.crossHair.SetActive(false);

        //destroy object
        Destroy(gameObject, Dtimer);
    }

    public void OnTriggerEnter(Collider inRange)
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!isEquiped && distanceToPlayer.magnitude < pickUpRange && !alrdyEquiped)
        {
            PickUp();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;

        //setup
        if (!isEquiped)
        {
            gun.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = true;
            gun.crossHair.SetActive(false);
        }

        if (isEquiped)
        {
            gun.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = false;
            alrdyEquiped = true;
            gun.crossHair.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!isEquiped && distanceToPlayer.magnitude < pickUpRange && Input.GetKeyDown(KeyCode.E) && !alrdyEquiped)
        {
            PickUp();
        }
        */

        if (isEquiped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }
}
