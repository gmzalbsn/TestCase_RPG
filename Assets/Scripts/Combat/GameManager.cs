using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public List<Hero> spawnHero = new List<Hero>();
    public GameObject enemyHero;
    public UnityEvent FailEvent;
    public UnityEvent SuccessEvent;
    public bool isContinue;
    public int casualties;

    public void Start()
    {
        isContinue = true;
    }
    public void LoadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void HeroAttackStage(Hero hero)
    {
        if (hero.GetComponent<HeroCombatController>().canAttack)
        {
            for (int i = 0; i < spawnHero.Count; i++)
            {
                spawnHero[i].GetComponent<HeroCombatController>().canAttack = true;
            }   
        }
        else
        {
            for (int i = 0; i < spawnHero.Count; i++)
            {
                spawnHero[i].GetComponent<HeroCombatController>().canAttack = false;
            }
        }
    }
    public void IsEnemyDead(BasicHero hero)
    {
        if (hero.heroStats.healthPoints<=0)
        {
            SuccessEvent.Invoke();
            isContinue = false;
        }
    }
    
    public void IsHeroDead()
    {

        casualties = spawnHero.FindAll(x => x.GetComponent<HeroCombatController>().isDead).Count;
        if (casualties== spawnHero.Count)
        {
            FailEvent.Invoke();
            isContinue = false;
        }


    }
}
