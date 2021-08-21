using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public HealthBarScript healthBar;
    public Transform camera;
    public float maxHP = 100f;
    public float currentHP;

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        healthBar.setHealth(currentHP);

        if (currentHP <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.setMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
