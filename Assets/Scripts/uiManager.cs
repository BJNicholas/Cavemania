﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreTXT;
    public Slider healthBar;



    private void Update()
    {
        healthBar.value = GameManager.instance.health;
        scoreTXT.text = GameManager.instance.score.ToString("00");
    }
}
