using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class CarPart : ScriptableObject{
    public string partName;
    public float cost;

    public abstract void SetVisual(CustomizedCar customCar);
}
