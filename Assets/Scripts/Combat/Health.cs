using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;
    private HeroCombatAbility heroCombatAbility;
    public void Start()
    {
        heroCombatAbility=GetComponent<HeroCombatAbility>();
        healthBar.maxValue = GetComponent<BasicHero>().heroStats.healthPoints;
        heroCombatAbility.healthEvent.AddListener(HealthBarControl);
        healthBar.value = healthBar.maxValue;
    }
    public void HealthBarControl()
    {
        healthBar.value = GetComponent<BasicHero>().heroStats.healthPoints;
    }
}
