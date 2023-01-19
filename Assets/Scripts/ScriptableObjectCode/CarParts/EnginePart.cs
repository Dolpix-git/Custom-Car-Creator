using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "engine", menuName = "Carpart/Engine"), Serializable]
public class EnginePart : CarPart{
    public float enginePower;

    public override void SetVisual(CustomizedCar customCar){

    }
}
