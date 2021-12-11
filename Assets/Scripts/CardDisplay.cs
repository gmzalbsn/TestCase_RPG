using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    public Text healthText;
    public Text attackText;
    private HeroSelector heroSelector;
    private HeroSpawn heroController;

    public void Start()
    {
        heroSelector = FindObjectOfType<HeroSelector>();
        heroController = FindObjectOfType<HeroSpawn>();
        var hero = GetComponent<Hero>();
        nameText.text = hero.name;
        healthText.text = "HP  " + hero.heroStats.healthPoints.ToString();
        attackText.text = "AP  " + hero.heroStats.attackPoints.ToString();
        
        GetComponent<Button>().onClick.AddListener(CarActive);
        GetComponent<Button>().onClick.AddListener(SelectedCharacters);
        GetComponent<Button>().onClick.AddListener(heroSelector.TaskOnClick);
        
    }
    public void CarActive()
    {
        if (heroSelector.characterCount > 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void SelectedCharacters()
    {
        if (heroSelector.characterCount > 0)
        {
            Hero myHero = GetComponent<Hero>();
            heroController.selectedHero.Add(myHero);
        }
    }
}
