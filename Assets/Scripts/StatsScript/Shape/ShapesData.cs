using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShape", menuName = "ShapesStats")]
public class ShapesData : ScriptableObject
{
    public List<ShapeStats> shapesStats;
    public HeroStats GetHeroShapeStats(Shapes shape)
    {
        foreach (var item in shapesStats)
        {
            if (item.shape== shape)
            {
                return  item.heroStats;
            }
        }
        return null;
    }
    public Mesh GetShapeMesh(Shapes shape)
    {
        foreach (var item in shapesStats)
        {
            if (item.shape== shape)
            {
                return item.mesh;
            }
        }
        return null;
    }
}
