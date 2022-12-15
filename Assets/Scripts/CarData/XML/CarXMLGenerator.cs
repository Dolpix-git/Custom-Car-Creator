using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class CarXMLGenerator : MonoBehaviour{
    [SerializeField] private string carName = "test";
    [SerializeField] private List<NamedCarData> carData;
    
    public void SaveXMLFile(){
        Dictionary<string, List<CarObject>> car = new Dictionary<string, List<CarObject>>();

        foreach (var data in carData){
            List<CarObject> carObjects = new List<CarObject>();
            foreach (var item in data.carObject){
                carObjects.Add(item);
            }
            car.Add(data.name, carObjects);
        }


        FileStream stream = new FileStream(Application.dataPath + "/Cars/XML Data/"+ carName + ".xml", FileMode.Create);
        XML.Serialize(stream, car);
        stream.Close();
        Debug.Log("Saved File");

        XML.FileCount();
    }
    public void LoadXMLFile(){
        Dictionary<string, List<CarObject>> car = new Dictionary<string, List<CarObject>>();

        try{
            FileStream stream = new FileStream(Application.dataPath + "/Cars/XML Data/" + carName + ".xml", FileMode.Open);
            XML.Deserialize(stream, ref car);
            stream.Close();
        }
        catch{
            Debug.LogError("Could not Load file with name: " + carName);
            return;
        }
        


        carData = new List<NamedCarData>();
        foreach (string key in car.Keys){
            carData.Add(new NamedCarData(key, car[key].ToArray()));
        }
        Debug.Log("Loaded File");
    }
}
