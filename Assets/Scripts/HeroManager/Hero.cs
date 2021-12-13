using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero : BasicHero
{
    public Shapes shape;
    public Sizes size;
    public Colors color;


    public void SetHeroProperties(Hero copyHero) {

        Name = copyHero.Name;
        heroStats = copyHero.heroStats;
        shape = copyHero.shape;
        size = copyHero.size;
        color = copyHero.color;
    }

  

}
