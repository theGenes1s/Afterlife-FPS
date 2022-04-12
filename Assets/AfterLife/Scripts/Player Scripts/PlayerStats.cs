using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image healthBar , staminaBar;
        public void Display_HealthStats (float healthValue)
        {
            healthValue /= 100f;
            healthBar.fillAmount = healthValue;
        }

         public void Display_staminaStats (float staminaValue)
        {
            staminaValue /= 100f;
            staminaBar.fillAmount = staminaValue;
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
