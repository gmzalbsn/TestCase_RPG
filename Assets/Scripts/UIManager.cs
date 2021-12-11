using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button battleButton;
    public GameObject startMenu;
    public GameObject winMenu;
    public GameObject failMenu;
    public GameObject selectedMenu;
    public Button playButton;
    public Button restartButton;
    public Button playAgainButton;

    public void Start()
    {
        ButtonStart();
    }
    public void ButtonStart()
    {
        playButton.onClick.AddListener(ButtonClick);
        restartButton.onClick.AddListener(ButtonClick);
        playAgainButton.onClick.AddListener(ButtonClick);
        restartButton.onClick.AddListener(LoadLevel);
        playAgainButton.onClick.AddListener(LoadLevel);
    }
    public void ButtonClick()
    {
        startMenu.SetActive(false);
        winMenu.SetActive(false);
        failMenu.SetActive(false);
    }
    public void LoadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MenuActive(GameObject menu,bool isActive)
    {
        StartCoroutine(MenuWait(menu, isActive));
    }
    public IEnumerator MenuWait(GameObject menu, bool isActive)
    {
        yield return new WaitForSeconds(3f);
        menu.SetActive(isActive);
    }

}
