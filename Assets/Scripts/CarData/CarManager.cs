using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour{
    public static CarManager Instance { get; private set; }
    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    private Dictionary<string, CarObject> currentCar = new Dictionary<string, CarObject>();

    public void ResetCarData(){
        currentCar.Clear();
    }

    public void AddObject(string key, CarObject value){
        currentCar.Add(key, value);
    }

    public void RemoveObject(string key){
        CarObject values;
        if (currentCar.TryGetValue(key, out values)){
            currentCar.Remove(key);
        }
    }
    public void AttemptReplace(string key, CarObject value){
        CarObject values;
        if (currentCar.TryGetValue(key, out values)){
            currentCar[key] = value;
        }else{
            AddObject(key, value);
        }
    }
    public float GetTotalCost(){
        float cost = 0;

        foreach (var item in currentCar.Values){
            cost += item.cost;
        }

        return cost;
    }
}
