using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour
{
    public Slider STMSlider;

    public void setMaxStm(float maxStamina)
    {
        STMSlider.maxValue = maxStamina;
        STMSlider.value = maxStamina;
    }

    public void setStm(float STamina)
    {
        STMSlider.value = STamina;
    }
}
