using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCreator : MonoBehaviour
{
    public ShapesStats shapeStats;
    public SizeStats sizeStats;
    public ColorStats colorStats;
    public Name name;

    public GameObject basicHero;
    public GameObject content;
    public List<Hero> heroes;
    public int heroCount;
    private void Start()
    {
        for (int i = 0; i < heroCount; i++)
        {
            CreateHero();
            
        }
        NameGenerator();
    }
    public int RandomNumber(int listLenght)
    {
        return Random.Range(0,listLenght);
     
    }
    public void NameGenerator()
    {
        for (int i = 0; i < heroCount; i++)
        {
            heroes[i].name= name.name[i];
        }
    }
    public void UpdateShapeStats(Hero hero)
    {
        hero.heroStats.AddStatsValues(shapeStats.GetHeroShapeStats(hero.shape));
    }
    public void UpdateSizeStats(Hero hero)
    {
        hero.heroStats.AddStatsValues(sizeStats.GetHeroSizeStats(hero.size));
    }
    public void UpdateColorStats(Hero hero)
    {
        hero.heroStats.AddStatsValues(colorStats.GetHeroColorStats(hero.color,hero.shape));
    }
    
    public void CreateHero()
    {
        GameObject newHero = Instantiate(basicHero);
        newHero.transform.parent = content.transform;
        Hero myHero = newHero.GetComponent<Hero>();
        myHero.shape = (Shapes)RandomNumber(shapeStats.shapesFeature.Count);
        myHero.color = (Colors)RandomNumber(colorStats.colorFeature.Count);
        myHero.size = (Sizes)RandomNumber(sizeStats.sizeFeature.Count);
        UpdateShapeStats(myHero);
        UpdateSizeStats(myHero);
        UpdateColorStats(myHero);
        
        heroes.Add(myHero); 
    }
}
