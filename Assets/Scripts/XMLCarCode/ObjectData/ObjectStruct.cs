using System;
using System.Collections.Generic;

[Serializable]
public struct CarObject{ // General struct used to store 4 data types per object
    public string name;
    public float cost;
}

[Serializable]
public class Car{ // Car class used for XML serilisation as XML doesnt suport Dictionarys
    public string key;
    public List<CarObject> value;

    public Car() { }
    public Car(string k, List<CarObject> v){
        key = k;
        value = v;
    }
}

[Serializable]
public class NamedCarData{ // Exsits so you can make cars in unity (unity doesnt support Dictionarys)
    public string name;
    public CarObject[] carObject;

    public NamedCarData(string n, CarObject[] co){
        name = n;
        carObject = co;
    }
}