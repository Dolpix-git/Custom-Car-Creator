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

    public Dictionary<PartKeys, Vector3[]> carPartsLocation = new Dictionary<PartKeys, Vector3[]>();
    public Dictionary<PartKeys, float[]> carPartsRotation = new Dictionary<PartKeys, float[]>();
    public Dictionary<PartKeys, CarPart[]> carParts = new Dictionary<PartKeys, CarPart[]>();

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

public enum PartKeys{
    Body,
    Wheel,
    Hat,
    Paint,
    Engine
}

[Serializable]
public class CarPartsLocationDict{
    [SerializeField] private PartKeys key;
    [SerializeField] private Vector3[] location;
    [SerializeField] private float[] rotation;

    public PartKeys Key { get => key; set => key = value; }
    public Vector3[] Location { get => location; set => location = value; }
    public float[] Rotation { get => rotation; set => rotation = value; }
}
[Serializable]
public class CarPartsDict{
    [SerializeField] private PartKeys key;
    [SerializeField] private CarPart[] options;

    public PartKeys Key { get => key; set => key = value; }
    public CarPart[] Options { get => options; set => options = value; }
}