using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "carModel", menuName = "CarModel/Carmodel")]
public class CarModel : ScriptableObject, ISerializationCallbackReceiver{
    public GameObject carModelPrefab;
    public string carName;
    public float cost;

    public CarPartsLocationDict[] carPartsLocationDict;
    public CarPartsDict[] carPartsDict;

    public Dictionary<string, Vector3[]> carPartsLocation = new Dictionary<string, Vector3[]>();
    public Dictionary<string, float[]> carPartsRotation = new Dictionary<string, float[]>();
    public Dictionary<string, CarPart[]> carParts = new Dictionary<string, CarPart[]>();

    public void OnAfterDeserialize(){
        try{
            carPartsLocation.Clear();
            carPartsRotation.Clear();
            carParts.Clear();

            foreach (var transform in carPartsLocationDict){
                carPartsLocation.Add(transform.Key, transform.Location);
                carPartsRotation.Add(transform.Key, transform.Rotation);
            }

            foreach (var part in carPartsDict){
                carParts.Add(part.Key, part.Options);
            }
        }
        catch
        {

        }
    }

    public void OnBeforeSerialize(){
        try{
            carPartsLocation.Clear();
            carPartsRotation.Clear();
            carParts.Clear();

            foreach (var transform in carPartsLocationDict){
                carPartsLocation.Add(transform.Key, transform.Location);
                carPartsRotation.Add(transform.Key, transform.Rotation);
            }

            foreach (var part in carPartsDict){
                carParts.Add(part.Key, part.Options);
            }
        }
        catch
        {

        }

    }
}

[Serializable]
public class CarPartsLocationDict{
    [SerializeField] private string key;
    [SerializeField] private Vector3[] location;
    [SerializeField] private float[] rotation;

    public string Key { get => key; set => key = value; }
    public Vector3[] Location { get => location; set => location = value; }
    public float[] Rotation { get => rotation; set => rotation = value; }
}
[Serializable]
public class CarPartsDict{
    [SerializeField] private string key;
    [SerializeField] private CarPart[] options;

    public string Key { get => key; set => key = value; }
    public CarPart[] Options { get => options; set => options = value; }
}