using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreTXT;
    public Slider healthBar;
    public Slider manaBar;
    public Text coinCounter;



    private void Update()
    {
        healthBar.value = GameManager.instance.health;
        manaBar.value = GameManager.instance.mana;
        scoreTXT.text = GameManager.instance.score.ToString("00");
        coinCounter.text = GameManager.instance.bankedScore.ToString("00");
    }
}
