using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "color", menuName = "Carpart/Color")]
public class ColorPart : CarPart{
    public Color color;
    public override void SetVisual(CustomizedCar customCar){
        customCar.material.color = color;
    }
}
