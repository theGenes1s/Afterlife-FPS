using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image healthBar,
        staminaBar;
/// <summary>
/// Show realtime updates of health and stamina
/// </summary>
/// <param name="healthValue"></param>
    public void Display_HealthStats(float healthValue)
    {
        healthValue /= 100f;
        healthBar.fillAmount = healthValue;
    }

    public void Display_staminaStats(float staminaValue)
    {
        staminaValue /= 100f;
        staminaBar.fillAmount = staminaValue;
    }


}
