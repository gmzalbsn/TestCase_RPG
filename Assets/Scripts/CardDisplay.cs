using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    public Text healthText;
    public Text attackText;

    public void SetCard(Hero hero)
    {
        nameText.text = hero.Name;
        healthText.text = "HP  " + hero.heroStats.healthPoints.ToString();
        attackText.text = "AP  " + hero.heroStats.attackPoints.ToString();
    }
}
