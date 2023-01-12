using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarPart : ScriptableObject{
    public string partName;
    public float cost;

    public abstract void SetVisual(CustomizedCar customCar);
}
