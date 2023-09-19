using UnityEngine;
using UnityEngine.UI;

public class UiPopupBase : MonoBehaviour, IPopout{
    [SerializeField] private Button testButton;
    public void Init(){
        testButton.onClick.AddListener(ButtonLogic);
    }

    private void ButtonLogic(){
        Debug.LogError("Button Click");
    }

    public void Open(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SetActive(true);
    }

    private void SetActive(bool isActive){
        gameObject.SetActive(isActive);
    }

    public void Close(){
        
    }

    public void Dispoe(){
        testButton.onClick.RemoveListener(ButtonLogic);
        SetActive(false);
    }
}