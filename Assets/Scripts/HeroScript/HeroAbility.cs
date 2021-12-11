using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAbility : MonoBehaviour , IAttackable, IDamageable
{
    Hero hero;



    private void Awake()
    {
        hero = GetComponent<Hero>();
    }

    public void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(hero.heroStats.attackPoints);
    }

    public void TakeDamage(int damage)
    {
        hero.heroStats.healthPoints -= damage;
    }

    public void Die()
    {
        if (hero.heroStats.healthPoints<=0)
        {
            Destroy(gameObject);
        }

    }

    
}
