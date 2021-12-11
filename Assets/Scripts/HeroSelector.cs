using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelector : MonoBehaviour
{
    public int characterCount;
    private UIManager manager;
    private HeroSpawn heroController;

    public void Start()
    {
        manager = GetComponent<UIManager>();
        heroController = GetComponent<HeroSpawn>();
        BattleButtonActive(false);
        manager.battleButton.onClick.AddListener(BattleButtonClick);
        manager.battleButton.onClick.AddListener(heroController.SpawnHero);
    }
    public void TaskOnClick()
    {
        if (characterCount > 0)
        {
            characterCount--;
            BattleButtonActive(false);
            if (characterCount == 0)
            {
                BattleButtonActive(true);
            }
        }
        else
        {
            BattleButtonActive(true);
        }

    }
    public void BattleButtonActive(bool isActive)
    {
        manager.battleButton.gameObject.SetActive(isActive);
    }
    public void BattleButtonClick()
    {
        manager.selectedMenu.gameObject.SetActive(false);
    }
}
