using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShape", menuName = "ShapesStats")]
public class ShapesStats : ScriptableObject
{
    public List<ShapeFeature> shapesFeature;
    public HeroStats GetHeroShapeStats(Shapes shape)
    {
        HeroStats heroStats=new HeroStats();
        foreach (var item in shapesFeature)
        {
            if (item.shape== shape)
            {
                heroStats = item.heroStats;
            }
        }
        return heroStats;
    }
}
