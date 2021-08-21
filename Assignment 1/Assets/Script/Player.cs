using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;

    //Stamina Related Variables
    public float maxStamina = 100;
    public float currentStamina;
    public bool isUnlimitedStamina;
    float unlimitedStaminaDuration;


    //Invulnarability related Variables
    public bool isInvulnarable;
    float invulDuration;

    //UI related
    public HealthBarScript HealthBar;
    public StaminaBarScript StaminaBar;

    private FirstPersonController thePlayer;

    private IEnumerator infinityStaminaC;
    private IEnumerator infinityHPC;
    public void TakeDamage(float damage)
    {
        if(isInvulnarable == true)
        {
            
        }
        else
        {
            currentHP -= damage;
            HealthBar.setHealth(currentHP);
            isInvulnarable = true;
        }
    }

    void StaminaManagement()
    {
        if(isUnlimitedStamina == true)
        {
            if(infinityStaminaC == null)
            {
                infinityStaminaC = infiniteStamina();
                StartCoroutine(infinityStaminaC);
            }
            currentStamina += (2 * Time.deltaTime);
        }
        else
        {
            if(infinityStaminaC != null)
            {
                StopCoroutine(infinityStaminaC);
                infinityStaminaC = null;
            }
            if (thePlayer.m_IsWalking == false)
            {
                currentStamina -= (10 * Time.deltaTime);
            }
            else
            {
                if (currentStamina >= maxStamina)
                {
                    currentStamina = maxStamina;
                }
                else
                {
                    currentStamina += (2 * Time.deltaTime);
                }
            }
        }
        StaminaBar.setStm(currentStamina);
    }


    private IEnumerator infiniteStamina()
    {
        while(true)
        {
            yield return new WaitForSeconds(unlimitedStaminaDuration);

            isUnlimitedStamina = false;
        }
    }

    void invulManagement()
    {
        if (isInvulnarable == true)
        {
            if(infinityHPC == null)
            {
                infinityHPC = becomeInvulnarable();
                StartCoroutine(infinityHPC);
            }
        }
        if(!isInvulnarable)
        {
            if (infinityHPC != null)
            {
                StopCoroutine(infinityHPC);
                infinityHPC = null;
            }
        }
    }

    private IEnumerator becomeInvulnarable()
    {
        while(true)
        {
            yield return new WaitForSeconds(invulDuration);

            isInvulnarable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentStamina = maxStamina;
        HealthBar.setMaxHealth(maxHP);
        StaminaBar.setMaxStm(maxStamina);

        isUnlimitedStamina = false;
        unlimitedStaminaDuration = 5;

        isInvulnarable = false;
        invulDuration = 3;

        thePlayer = gameObject.GetComponent<FirstPersonController>();
    }

    void die()
    {
        if (currentHP < 1)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("CSCI356_Scene2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        StaminaManagement();
        invulManagement();
        die();
    }
}
