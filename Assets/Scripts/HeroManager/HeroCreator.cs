using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCreator : MonoBehaviour
{
    public GameManager gameManager;
    [Header("Hero")]
    public ShapesData shapeData;
    public SizesData sizeData;
    public ColorData colorData;
    public NameData name;
    public GameObject basicHero;
    public GameObject content;
    [Header("SelectedHero")]
    public List<Hero> heroes;
    public GameObject spawnHeroPrefab;
    public HeroSelectManager selectManager;
    public List<Transform> heroBattleTransform;
    [Header("Enemy")]
    public GameObject enemyPrefab;
    public Transform enemyTransform;
    public int heroCount;
    private void Start()
    {
        for (int i = 0; i < heroCount; i++)
        {
            CreateHero(i);
        }
    }
    public int RandomNumber(int listLenght)
    {
        return Random.Range(0, listLenght);
    }
    public void UpdateShapeStats(Hero hero)
    {
        hero.heroStats.AddStatsValues(shapeData.GetHeroShapeStats(hero.shape));
    }
    public void UpdateSizeStats(Hero hero)
    {
        hero.heroStats.AddStatsValues(sizeData.GetHeroSizeStats(hero.size));
    }
    public void UpdateColorStats(Hero hero)
    {
        hero.heroStats.AddStatsValues(colorData.GetHeroColorStats(hero.color, hero.shape));
    }

    public void CreateHero(int indexNumber)
    {
        GameObject newHero = Instantiate(basicHero);
        newHero.transform.parent = content.transform;
        Hero myHero = newHero.GetComponent<Hero>();
        myHero.Name = name.name[indexNumber];

        myHero.shape = (Shapes)RandomNumber(shapeData.shapesStats.Count);
        UpdateShapeStats(myHero);

        myHero.color = (Colors)RandomNumber(colorData.colorStats.Count);
        UpdateColorStats(myHero);

        myHero.size = (Sizes)RandomNumber(sizeData.sizeStats.Count);
        UpdateSizeStats(myHero);

        newHero.GetComponent<CardDisplay>().SetCard(myHero);
        heroes.Add(myHero);

    }
    public void SpawnHeroes()
    {
        GameObject enemy=Instantiate(enemyPrefab, enemyTransform.position, Quaternion.identity);
        gameManager.enemyHero = enemy;
        for (int i = 0; i < selectManager.selectedHeros.Count; i++)
        {
            Hero hero = Instantiate(spawnHeroPrefab, heroBattleTransform[i].position, Quaternion.identity).GetComponent<Hero>();
            hero.SetHeroProperties(selectManager.selectedHeros[i]);
            hero.InitializeMeshComponent();
            hero.SetMesh(shapeData.GetShapeMesh(hero.shape));
            hero.SetMaterial(colorData.GetColorMaterial(hero.color));
            hero.transform.localScale *= sizeData.GetSizeMultiplier(hero.size);
            SetHeroYTransform(hero);
            gameManager.spawnHero.Add(hero);
            hero.GetComponent<HeroCombatController>().SetTarget(enemy);
        }
        
    }

    public void SetHeroYTransform(Hero hero)
    {
        float newYPosition = 0f;
        switch (hero.shape)
        {
            case Shapes.Square:
                newYPosition = hero.transform.localScale.y / 2;
                break;
            case Shapes.Circle:
                newYPosition = hero.transform.localScale.y;
                break;
            default:
                break;
        }
        hero.transform.position = new Vector3(hero.transform.position.x, newYPosition, hero.transform.position.z);
    }
}
