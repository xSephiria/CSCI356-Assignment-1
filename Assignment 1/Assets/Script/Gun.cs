using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 20;
    public float fireRate = 15f;
    public Camera fpsCam;
    private float nextTimeToFire = 0f;
    public float ammo;

    public Text ammoDisplay;
    public GameObject crossHair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = "Ammo: " + ammo.ToString();

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            ammo--;
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100f))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
