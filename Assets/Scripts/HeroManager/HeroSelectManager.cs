using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HeroSelectManager : MonoBehaviour
{
    public int selectHeroCount;
    public List<Hero> selectedHeros=new List<Hero>();
    private bool canSelect;
    [HideInInspector]
    public UnityEvent OnHeroSelectedCompleted;
    public void Start()
    {
        canSelect = true;
    }
    public void SelectHero(Hero hero)
    {
        if (canSelect)
        {
            selectedHeros.Add(hero);
            selectHeroCount--;
            if (selectHeroCount==0)
            {
                canSelect = false;
                OnHeroSelectedCompleted.Invoke();
            }
        }
        
    }
}
