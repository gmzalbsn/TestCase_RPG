using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public HeroSelectManager heroSelectManager;
    public Button battleButton;
    public GameManager gameManager;
    public GameObject winMenu;
    public GameObject failMenu;
    public GameObject selectedMenu;
    public Button restartButton;
    public Button playAgainButton;
    
    public void Start()
    {
        heroSelectManager.OnHeroSelectedCompleted.AddListener(BattleButtonActive);
        battleButton.onClick.AddListener(BattleButtonClick);
        RestartButtonStart();
        gameManager.FailEvent.AddListener(FailMenu);
        gameManager.SuccessEvent.AddListener(WinMenu);
    }
    public void BattleButtonActive()
    {
        battleButton.gameObject.SetActive(true);
    }
    public void BattleButtonClick()
    {
        selectedMenu.SetActive(false);
    }
   
    public void RestartButtonStart()
    {
        restartButton.onClick.AddListener(ButtonClick);
        playAgainButton.onClick.AddListener(ButtonClick);
    }
    public void ButtonClick()
    {
        winMenu.SetActive(false);
        failMenu.SetActive(false);
        gameManager.LoadLevel();
    }
    public void FailMenu()
    {
        failMenu.SetActive(true);
    }
    public void WinMenu()
    {
        winMenu.SetActive(true);
    }
}
