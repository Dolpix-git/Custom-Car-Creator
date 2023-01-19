using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData{
    public CarModel carModel;
    public SerializableDictionary<PartKeys, CarPart> carData;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData(CarModel c){
        carModel = c;
        carData = new SerializableDictionary<PartKeys, CarPart>();

        foreach (var carPart in carModel.carParts){
            carData.Add(carPart.Key, carPart.Value[0]);
        }
    }
}