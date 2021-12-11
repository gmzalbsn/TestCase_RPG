using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawn : MonoBehaviour
{
    public List<Hero> selectedHero = new List<Hero>();
    public Transform[] heroParents;
    private GameObject heroSpawn;
    private List<GameObject> hero = new List<GameObject>();
    [Header("HeroPrefabs")]
    public GameObject heroSquare;
    public GameObject heroCircle;
    [Header("HeroMaterials")]
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    [Header("HeroSizes")]
    public float heroSmallSize;
    public float heroBigSize;
    [Header("Enemy")]
    public Transform enemyParent;
    public GameObject enemyPrefabs;
    public GameObject currentEnemy;


    public void BodyControl(int heroNumber)
    {
        switch (selectedHero[heroNumber].shape)
        {
            case Shapes.Square:
                heroSpawn = heroSquare;
                break;
            case Shapes.Circle:
                heroSpawn = heroCircle;
                break;
            default:
                break;
        }
        switch (selectedHero[heroNumber].color)
        {
            case Colors.Red:
                heroSpawn.GetComponent<MeshRenderer>().material = redMaterial;
                break;
            case Colors.Green:
                heroSpawn.GetComponent<MeshRenderer>().material = greenMaterial;
                break;
            case Colors.Blue:
                heroSpawn.GetComponent<MeshRenderer>().material = blueMaterial;
                break;
            default:
                break;
        }
        switch (selectedHero[heroNumber].size)
        {
            case Sizes.Big:
                heroSpawn.transform.localScale = new Vector3(heroBigSize, heroBigSize, heroBigSize);
                break;
            case Sizes.Small:
                heroSpawn.transform.localScale = new Vector3(heroSmallSize, heroSmallSize, heroSmallSize);
                break;
            default:
                break;
        }
    }
    public void SpawnHero()
    {
        SpawnEnemy();
        for (int i = 0; i < selectedHero.Count; i++)
        {
            BodyControl(i);
            GameObject newHero = Instantiate(heroSpawn);
            newHero.transform.parent = heroParents[i].transform;
            newHero.transform.position = heroParents[i].transform.position;
            newHero.GetComponent<Hero>().heroStats= selectedHero[i].heroStats;
            newHero.GetComponent<Hero>().shape = selectedHero[i].shape;
            newHero.GetComponent<Hero>().size = selectedHero[i].size;
            newHero.GetComponent<Hero>().color= selectedHero[i].color;
            hero.Add(newHero);
        }
    }
    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefabs);
        currentEnemy = enemy;
        enemy.transform.parent = enemyParent.transform;
        enemy.transform.position = enemyParent.transform.position;
    }
}
