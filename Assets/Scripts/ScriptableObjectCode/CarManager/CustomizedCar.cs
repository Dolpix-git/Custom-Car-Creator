using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedCar : MonoBehaviour{
    public CarModel carModel;
    public Material material;

    public Dictionary<string, CarPart> carData = new Dictionary<string, CarPart>();
    private Dictionary<string, List<GameObject>> carVisuals = new Dictionary<string, List<GameObject>>();

    public void ChangeCarData(CarModel c){
        // Wipe and prepare data.
        carModel = c;
        WipeVisuals();
        carData.Clear();

        // Add the main car visual
        SpawnVisuals("Body", carModel.carModelPrefab, Vector3.up * 0.5f, 0);

        // Too do: add all the default car parts and there visuals
        foreach (var carPart in carModel.carParts){
            carData.Add(carPart.Key,carPart.Value[0]);
            carPart.Value[0].SetVisual(this);
        }
    }

    public void ChangeCarPart(string key, CarPart value){
        if (carData[key] != null){
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

    public void SpawnVisuals(string key, GameObject prefab, Vector3 pos, float rot){
        if (carVisuals.TryGetValue("Body", out List<GameObject> parent)){
            carVisuals.TryAdd(key, new List<GameObject>());

            GameObject newVisual = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent[0].transform);
            newVisual.transform.localPosition = pos;
            newVisual.transform.localRotation = Quaternion.Euler(0, rot, 0);

            newVisual.name = key;
            carVisuals[key].Add(newVisual);
        }
        else{
            carVisuals.TryAdd(key, new List<GameObject>());

            GameObject newVisual = Instantiate(prefab, pos, Quaternion.Euler(0, rot, 0));
            newVisual.name = key;
            carVisuals[key].Add(newVisual);
        }
        
    }
    public void DespawnVisuals(string key){
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
}
