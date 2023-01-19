using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour{
    [SerializeField] private GameObject[] scenes;
    private int sceneIndex;

    public void NextScene(){
        scenes[sceneIndex].SetActive(false);
        sceneIndex++;
        sceneIndex %= scenes.Length;
        scenes[sceneIndex].SetActive(true);
    }

    public void PreviousScene(){
        scenes[sceneIndex].SetActive(false);
        sceneIndex--;
        if (sceneIndex < 0) { sceneIndex = scenes.Length - 1; }
        scenes[sceneIndex].SetActive(true);
    }
}
