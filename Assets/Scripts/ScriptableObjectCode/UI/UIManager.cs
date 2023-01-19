using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour{
    [SerializeField] private GameObject escapeMenu;
    [SerializeField] private GameObject customCarUI;
    [SerializeField] private GameObject controllsUI;
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            ToggleEscapeMenu();
        }
    }

    public void ToggleEscapeMenu(){
        customCarUI.SetActive(escapeMenu.activeSelf);
        controllsUI.SetActive(false);
        escapeMenu.SetActive(!escapeMenu.activeSelf);
    }
    public void ToggleControllsUI(){
        customCarUI.SetActive(false);
        escapeMenu.SetActive(controllsUI.activeSelf);
        controllsUI.SetActive(!controllsUI.activeSelf);
    }

    public void QuitTheAplication(){
        Application.Quit();
    }
}
