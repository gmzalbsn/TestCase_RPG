using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill : MonoBehaviour
{
    private HeroSpawn heroSpawn;
    public float speed = 0.1F;
    private bool isAttack = false;
    private bool isAttackFinish = false;
    private bool isDamage = false;
    private bool isDamageFinish = false;
    private bool isStart = true;
    public UIManager manager;
    [Header("Hero")]
    private GameObject currentHeroParent;
    private GameObject currenHero;
    private Transform heroTransform;
    private Vector3 heroStartPos;
    private Health currentHeroHealth;
    [Header("Enemy")]
    private Health enemyHealth;
    private GameObject enemyParent;
    private Transform enemyTransform;
    private Vector3 enemystartPos;

    public void Start()
    {
        manager = GetComponent<UIManager>();
        heroSpawn = GetComponent<HeroSpawn>();
        EnemyPositionGet();
    }
    public void EnemyPositionGet()
    {
        enemyParent = heroSpawn.enemyParent.gameObject;
        enemystartPos = enemyParent.transform.position;
        enemyTransform = enemyParent.transform;
    }
    public void Attack()
    {
        if (isAttack)
        {
            LerpTransform(currentHeroParent, heroTransform, enemystartPos);
            if (currentHeroParent.transform.position == enemystartPos)
            {
                isAttack = false;
                isAttackFinish = true;
            }
        }
        if (isAttackFinish)
        {
            LerpTransform(currentHeroParent, heroTransform, heroStartPos);
            if (currentHeroParent.transform.position == heroStartPos)
            {
                isAttackFinish = false;
                isDamage = true;
            }

        }
    }
    public void LerpTransform(GameObject character, Transform start, Vector3 end)
    {
        start.position = Vector3.Lerp(start.position, end, Time.deltaTime * speed);
    }
    public IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(4f);
        Damage();
    }
    public void HealthDecline(Hero attackHero, Hero damageHero)
    {
        int attack = attackHero.heroStats.attackPoints;
        int health = damageHero.heroStats.healthPoints;
        float result = (float)attack / health;

        damageHero.heroStats.healthPoints=health-attack;
        damageHero.gameObject.GetComponent<Health>().healthFullBar.fillAmount -= result;
        if (damageHero.gameObject.GetComponent<Health>().healthFullBar.fillAmount<= 0)
        {
            if (damageHero.gameObject.tag=="Player")
            {
                manager.MenuActive(manager.failMenu, true);
            }
            else
            {
                manager.MenuActive(manager.winMenu, true);
            }
        }
    }
    public void Damage()
    {
        if (isDamage)
        {
            LerpTransform(enemyParent, enemyTransform, heroStartPos);
            if (enemyParent.transform.position == heroStartPos)
            {
                isDamage = false;
                isDamageFinish = true;
                Hero attackHero = currenHero.GetComponent<Hero>();
                Hero attackEnemy = heroSpawn.currentEnemy.GetComponent<Hero>();
                HealthDecline(attackEnemy, attackHero);
            }
        }
        if (isDamageFinish)
        {
            LerpTransform(enemyParent, enemyTransform, enemystartPos);
            if (enemyParent.transform.position==enemystartPos)
            {
                isAttack = false;
                isAttackFinish = false;
                isDamage = false;
                isDamageFinish = false;
                isStart = true;
            }
        }
    }
    void Update()
    {
        if (isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        isStart = false;
                        currenHero = hit.transform.gameObject;
                        currentHeroParent = hit.transform.parent.gameObject;
                        heroTransform = currentHeroParent.transform;
                        heroStartPos = hit.transform.parent.position;
                        isAttack = true;
                        Hero attackHero = hit.transform.gameObject.GetComponent<Hero>();
                        Hero attackEnemy = heroSpawn.currentEnemy.GetComponent<Hero>();
                        HealthDecline(attackHero, attackEnemy);
                    }

                }

            }
        }
        Attack();
        StartCoroutine(DamageWait());
    }
}
