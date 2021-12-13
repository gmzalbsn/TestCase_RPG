using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelector : MonoBehaviour
{
    private HeroSelectManager heroSelectManager;
    private Button cardButton;
    public void Awake()
    {
        cardButton = GetComponent<Button>();
        cardButton.onClick.AddListener(SelectHeroClick);
    }
    public void Start()
    {
        heroSelectManager = FindObjectOfType<HeroSelectManager>();
    }
    public void SelectHeroClick()
    {
        if (heroSelectManager.selectHeroCount!=0)
        {
            heroSelectManager.SelectHero(GetComponent<Hero>());
            gameObject.SetActive(false);
        } 
    }
}
