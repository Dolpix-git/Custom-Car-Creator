using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedCar : MonoBehaviour, IDataPersistence{
    public CarModel carModel;
    public Material material;

    public Dictionary<PartKeys, CarPart> carData = new Dictionary<PartKeys, CarPart>();
    private Dictionary<PartKeys, List<GameObject>> carVisuals = new Dictionary<PartKeys, List<GameObject>>();

    public void ChangeCarData(CarModel c){
        // Wipe and prepare data.
        carModel = c;
        WipeVisuals();
        
        Dictionary<PartKeys, CarPart> carDataCopy = new Dictionary<PartKeys, CarPart>(carData);
        carData.Clear();

        // Add the main car visual
        SpawnVisuals(PartKeys.Body, carModel.carModelPrefab, Vector3.up * 0.5f, 0);

        // Too do: add all the default car parts and there visuals
        foreach (var carPart in carModel.carParts){
            bool partSpawnFlag = true;
            if (carDataCopy.TryGetValue(carPart.Key, out CarPart carBit)){ // Attempts to keep as many of the last items to this car as possible.
                foreach (var item in carPart.Value){
                    if (item == carBit) {
                        carData.Add(carPart.Key, carBit);
                        carBit.SetVisual(this);
                        partSpawnFlag = false;
                        break;
                    }
                }
            }
            if (partSpawnFlag){
                carData.Add(carPart.Key, carPart.Value[0]);
                carPart.Value[0].SetVisual(this);
            }
        }
    }

    public void ChangeCarPart(PartKeys key, CarPart value){
        if (carData.TryGetValue(key,out CarPart c)){
            DespawnVisuals(key);
            carVisuals.Remove(key);
            carData.Remove(key);
        }
        carData.Add(key, value);
        carData[key].SetVisual(this);

    }

    public void WipeVisuals(){
        foreach (var keys in carVisuals.Keys){
            DespawnVisuals(keys);
        }
        carVisuals.Clear();
    }

    public void SpawnVisuals(PartKeys key, GameObject prefab, Vector3 pos, float rot){
        if (carVisuals.TryGetValue(PartKeys.Body, out List<GameObject> parent)){
            carVisuals.TryAdd(key, new List<GameObject>());

            GameObject newVisual = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent[0].transform);
            newVisual.transform.localPosition = pos;
            newVisual.transform.localRotation = Quaternion.Euler(0, rot, 0);

            newVisual.name = key.ToString();
            carVisuals[key].Add(newVisual);
        }
        else{
            carVisuals.TryAdd(key, new List<GameObject>());

            GameObject newVisual = Instantiate(prefab, pos, Quaternion.Euler(0, rot, 0));
            newVisual.name = key.ToString();
            carVisuals[key].Add(newVisual);
        }
        
    }
    public void DespawnVisuals(PartKeys key){
        if (carVisuals.TryGetValue(key, out List<GameObject> visuals)){
            foreach (var visual in visuals){
                Destroy(visual);
            }
        }
    }

    public float RetrunPrice(){
        float cost = carModel.cost;
        foreach (CarPart data in carData.Values){
            cost += data.cost;
        }

        return cost;
    }

    public void LoadData(GameData data){
        carModel = data.carModel;
        carData = new Dictionary<PartKeys, CarPart>(data.carData);
        ChangeCarData(carModel);
    }

    public void SaveData(ref GameData data){
        data.carModel = carModel;
        data.carData = new SerializableDictionary<PartKeys, CarPart>();
        foreach (var item in carData){
            data.carData.Add(item.Key,item.Value);
        }
    }
}
