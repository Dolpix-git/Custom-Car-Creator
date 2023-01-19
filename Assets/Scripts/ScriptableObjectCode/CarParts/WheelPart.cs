using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "wheel", menuName = "Carpart/Wheel"), Serializable]
public class WheelPart : CarPart{
    public GameObject wheelPrefab;
    public Texture2D icon;
    public override void SetVisual(CustomizedCar customCar){
        for (int i = 0; i < customCar.carModel.carPartsLocation[PartKeys.Wheel].Length; i++){
            customCar.SpawnVisuals(PartKeys.Wheel, wheelPrefab, customCar.carModel.carPartsLocation[PartKeys.Wheel][i], customCar.carModel.carPartsRotation[PartKeys.Wheel][i]);
        }
    }
}
