using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataBaseManager : MonoBehaviour{
    [SerializeField] private CarModel[] carDataBase;
    private CustomizedCar customizedCar;

    public CarModel[] CarDataBase { get => carDataBase; set => carDataBase = value; }

    public CatagoryImage[] catagory;

    public Dictionary<PartKeys, GameObject> catagoryDict;

    private void Awake(){
        customizedCar = transform.GetComponent<CustomizedCar>();
        LoadCar(CarDataBase[0]);

        catagoryDict = new Dictionary<PartKeys, GameObject>();
        foreach (var item in catagory){
            catagoryDict.Add(item.key,item.catagoryImage);
        }
    }

    public void LoadCar(CarModel c){
        customizedCar.ChangeCarData(c);
    }
}

[Serializable]
public class CatagoryImage{
    public PartKeys key;
    public GameObject catagoryImage;
}
