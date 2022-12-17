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
public struct TagWithCost
{
    public string tag;
    public float cost;
}
[Serializable]
public struct ColorWithCost
{
    public string tag;
    public float cost;
    public Color color;
}
[Serializable]
public struct WheelWithcost
{
    public string tag;
    public float cost;
    public GameObject wheel;
}
[Serializable]
public struct ModelTypes
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


    public ModelTypes[] modelTypes;
    public ColorWithCost[] paint;
    public WheelWithcost[] wheels;
    public TagWithCost[] towHitch;
    public ColorWithCost[] interior;
    public TagWithCost[] seatingLayout;
    public TagWithCost[] enhancedAutoPilot;
    public TagWithCost[] FSD;
}