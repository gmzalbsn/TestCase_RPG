using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSize", menuName = "SizeStats")]
public class SizeStats : ScriptableObject
{
    public List<SizeFeature> sizeFeature;

    public HeroStats GetHeroSizeStats(Sizes size)
    {
        HeroStats heroStats = new HeroStats();
        foreach (var item in sizeFeature)
        {
            if (item.size==size)
            {
                heroStats = item.heroStats;
            }
        }
        return heroStats;
    }
}
