using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColor", menuName = "ColorStats")]
public class ColorData : ScriptableObject
{
    public List<ColorStats> colorStats;

    public HeroStats GetHeroColorStats(Colors color, Shapes shape)
    {
        foreach (var item in colorStats)
        {
            if (item.color == color)
            {
                foreach (var x in item.colorSubStats)
                {
                    if (x.shape == shape)
                    {
                        return x.heroStats;
                    }

                }
            }
        }
        return null;
    }
    public Material GetColorMaterial(Colors color)
    {
        foreach (var item in colorStats)
        {
            if (item.color == color)
            {
                return item.material;
            }
        }
        return null;
    }
}


