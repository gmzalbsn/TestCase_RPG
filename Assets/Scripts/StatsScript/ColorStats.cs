using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColor", menuName = "ColorStats")]
public class ColorStats : ScriptableObject
{
    public List<ColorFeature> colorFeature;

    public HeroStats GetHeroColorStats(Colors color,Shapes shape)
    {
        HeroStats heroStats = new HeroStats();
        foreach (var item in colorFeature)
        {
            if (item.color==color)
            {
                foreach (var x in item.shapeFeatures)
                {
                    if (x.shape == shape)
                    {
                        heroStats = x.heroStats;
                    }
                    
                }
            }
        }
        return heroStats;
    }
}
