using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarData : MonoBehaviour{
    [SerializeField] public Model[] Data;
}

[Serializable]
public struct tagWithCost
{
    public string tag;
    public float cost;
}
[Serializable]
public struct colorWithCost
{
    public string tag;
    public float cost;
    public Color color;
}
[Serializable]
public struct wheelWithcost
{
    public string tag;
    public float cost;
    public GameObject wheel;
}
[Serializable]
public struct modelTypes
{
    public string tag;
    public float cost;

    public float range;
    public float topSpeed;
    public float acceleration;
}

[Serializable]
public class Model{
    public string modelName;
    public GameObject carWithNoWheels;
    public GameObject uiOptions;
    public TextMeshProUGUI price;
    public Material carPaint;
    public Material interiorPaint;


    public modelTypes[] modelTypes;
    public colorWithCost[] paint;
    public wheelWithcost[] wheels;
    public tagWithCost[] towHitch;
    public colorWithCost[] interior;
    public tagWithCost[] seatingLayout;
    public tagWithCost[] enhancedAutoPilot;
    public tagWithCost[] FSD;
}