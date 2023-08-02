using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthBar : MonoBehaviour{
    public Image image;

    private void OnValidate(){
        image = GetComponent<Image>();
    }

    public void SetupBar(float maxHealth, float currentHealth){
        image.fillAmount = currentHealth / maxHealth;
    } 
}