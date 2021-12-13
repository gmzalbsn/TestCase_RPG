using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HeroCombatAbility : MonoBehaviour , IAttackable, IDamageable
{
    BasicHero hero;
    public UnityEvent healthEvent;
    
    private void Awake()
    {
        hero = GetComponent<BasicHero>(); 
    }

    public void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(hero.heroStats.attackPoints);   
    }

    public void TakeDamage(int damage)
    {
        hero.heroStats.healthPoints -= damage;
        healthEvent.Invoke();
        Die();
    }
    public void Die()
    {
        if (hero.heroStats.healthPoints<=0)
        {
            gameObject.SetActive(false);   
        }

    }
    

    
}
