using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "hat", menuName = "Carpart/Hat")]
public class HatPart : CarPart{
    public GameObject HatPrefab;

    public override void SetVisual(CustomizedCar customCar){
        for (int i = 0; i < customCar.carModel.carPartsLocation["Hat"].Length; i++){
            customCar.SpawnVisuals("Hat", HatPrefab, customCar.carModel.carPartsLocation["Hat"][i], customCar.carModel.carPartsRotation["Hat"][i]);
        }
    }
}
