using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class HeroStats
{
    public int healthPoints;
    public int attackPoints;

    public void AddStatsValues(HeroStats newHeroStats)
    {
        healthPoints += newHeroStats.healthPoints;
        attackPoints += newHeroStats.attackPoints;
    }
}
