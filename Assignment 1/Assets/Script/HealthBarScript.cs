using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider HPSlider;

    public void setMaxHealth(float maxHealth)
    {
        HPSlider.maxValue = maxHealth;
        HPSlider.value = maxHealth;
    }

    public void setHealth(float health)
    {
        HPSlider.value = health;
    }
}
