using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "wheel", menuName = "Carpart/Wheel")]
public class WheelPart : CarPart{
    public GameObject wheelPrefab;
    public Texture2D icon;
    public override void SetVisual(CustomizedCar customCar){
        for (int i = 0; i < customCar.carModel.carPartsLocation["Wheel"].Length; i++){
            customCar.SpawnVisuals("Wheel", wheelPrefab, customCar.carModel.carPartsLocation["Wheel"][i], customCar.carModel.carPartsRotation["Wheel"][i]);
        }
    }
}
