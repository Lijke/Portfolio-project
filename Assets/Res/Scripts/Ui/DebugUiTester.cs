using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class DebugUiTester : MonoBehaviour{
    [SerializeField] private UiPopupBase ui;

    [Button()]
    public void OpenPopup(){
        UiPopupManager.Instance.Open(ui);
    }

    private void Update(){
        if (Input.GetKey(KeyCode.P)){
            UiPopupManager.Instance.Open(ui);
        }

        if (Input.GetKey(KeyCode.K)){
            UiPopupManager.Instance.Close(ui);
        }
    }
}
