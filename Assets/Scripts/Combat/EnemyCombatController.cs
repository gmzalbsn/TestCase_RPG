using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyCombatController : MonoBehaviour
{
    private HeroCombatAbility heroCombatAbility;
    private GameManager gameManager;
    public GameObject hero;
    private Vector3 startTransform;
    public float speed=5f;
    void Start()
    {
        heroCombatAbility = GetComponent<HeroCombatAbility>();
        startTransform= gameObject.transform.position;
        gameManager = FindObjectOfType<GameManager>();
        
    }
  
    public void SetTarget(GameObject heroTarget)
    {
        hero = heroTarget;
    }
    IEnumerator AttackAnimation()
    {
        bool isEnded = false;
        bool isMoving = true;
        while (isMoving)
        {
            if (!isEnded)
            {
                transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, Time.deltaTime * speed);
                if (transform.position == hero.transform.position)
                {
                    isEnded = true;
                    heroCombatAbility.Attack(hero.GetComponent<IDamageable>());
                    
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startTransform, Time.deltaTime * speed);
                if (transform.position == startTransform)
                {
                    isMoving = false;
                }
            }
            yield return null;
        }
        hero.GetComponent<HeroCombatController>().canAttack = true;
        gameManager.HeroAttackStage(hero.GetComponent<Hero>());
        if (hero.GetComponent<Hero>().heroStats.healthPoints <= 0)
        {
            hero.GetComponent<HeroCombatController>().isDead = true;
            gameManager.IsHeroDead();

        }

    }
    public void EnemyAttack()
    {
        if (gameManager.isContinue)
        {
            StartCoroutine(AttackAnimation());
        }  
    }

}
