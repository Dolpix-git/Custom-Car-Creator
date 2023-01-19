using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "hat", menuName = "Carpart/Hat"), Serializable]
public class HatPart : CarPart{
    public GameObject HatPrefab;

    public override void SetVisual(CustomizedCar customCar){
        for (int i = 0; i < customCar.carModel.carPartsLocation[PartKeys.Hat].Length; i++){
            customCar.SpawnVisuals(PartKeys.Hat, HatPrefab, customCar.carModel.carPartsLocation[PartKeys.Hat][i], customCar.carModel.carPartsRotation[PartKeys.Hat][i]);
        }
    }
}
