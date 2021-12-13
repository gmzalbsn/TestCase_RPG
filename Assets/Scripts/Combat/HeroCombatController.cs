using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroCombatController : MonoBehaviour
{
    private HeroCombatAbility heroCombatAbility;
    private GameManager gameManager;
    public GameObject enemy;
    public Vector3 startTransform;
    public float speed=5f;
    public bool canAttack=true;
    public UnityEvent OnHeroAttackFinished;
    public bool isDead=false;
    // Start is called before the first frame update
    void Start()
    {
        heroCombatAbility = GetComponent<HeroCombatAbility>();
        gameManager = FindObjectOfType<GameManager>();
        startTransform = gameObject.transform.position;
        
    }
    public void SetTarget(GameObject enemyTarget)
    {
        enemy = enemyTarget;
    }
    IEnumerator AttackAnimation()
    {
        bool isEnded = false;
        bool isMoving = true;
        while (isMoving)
        {
            if (!isEnded)
            {
                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * speed);
                if (transform.position == enemy.transform.position)
                {
                    isEnded = true;
                    heroCombatAbility.Attack(enemy.GetComponent<IDamageable>());
                    gameManager.IsEnemyDead(enemy.GetComponent<BasicHero>());

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
        OnHeroAttackFinished.Invoke();
    }
    public void OnMouseDown()
    {
        if (gameManager.isContinue)
        {
            if (canAttack)
            {
                enemy.GetComponent<EnemyCombatController>().hero = gameObject;
                OnHeroAttackFinished.AddListener(enemy.GetComponent<EnemyCombatController>().EnemyAttack);
                StartCoroutine(AttackAnimation());

                canAttack = false;
                gameManager.HeroAttackStage(enemy.GetComponent<EnemyCombatController>().hero.GetComponent<Hero>());
            }
        }
    }
   
}
