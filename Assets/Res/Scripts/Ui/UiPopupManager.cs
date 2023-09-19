using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPopoutManager{
    void RegisterPopUp();
    void Open(UiPopupBase uiPopupBase);
    void Close(UiPopupBase uiPopupBase);
}
public class UiPopupManager : MonoBehaviour, IPopoutManager{
    public static UiPopupManager Instance { get; private set; }
    
    private List<UiPopupBase> popupList = new List<UiPopupBase>();
    private UiPopupBase openPopup;
    private void Awake(){
        Instance = this;
        RegisterPopUp();
    }

    public void RegisterPopUp(){
        GetComponentsInChildren(true, popupList);
        Debug.LogError(popupList.Count);
    }

    public void Open(UiPopupBase uiPopupBase){
        if (openPopup != null){
            Close(openPopup);
        }

        openPopup = uiPopupBase;
        openPopup.Init();
        openPopup.Open();
    }

    public void Close(UiPopupBase uiPopupBase){
        uiPopupBase.Dispoe();
        uiPopupBase.Close();
    }
    
}
