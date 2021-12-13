using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSize", menuName = "SizeStats")]
public class SizesData : ScriptableObject
{
    public List<SizeStats> sizeStats;

    public HeroStats GetHeroSizeStats(Sizes size)
    {
        foreach (var item in sizeStats)
        {
            if (item.size==size)
            {
                return item.heroStats;
            }
        }
        return null;
    }
    public float GetSizeMultiplier(Sizes size)
    {
        foreach (var item in sizeStats)
        {
            if (item.size==size)
            {
                return item.sizeMultiplier;
            }
        }
        return 0;
    }
}
