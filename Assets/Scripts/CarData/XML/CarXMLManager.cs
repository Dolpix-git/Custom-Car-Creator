using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarXMLManager : MonoBehaviour{
    public static CarXMLManager Instance { get; private set; }
    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }


        ChooseDatabase(XML.FileList()[0]);
    }

    public Dictionary<string, List<CarObject>> currentCarDatabase = new Dictionary<string, List<CarObject>>();

    public void ChooseDatabase(FileInfo file){
        currentCarDatabase = new Dictionary<string, List<CarObject>>();

        FileStream stream = new FileStream(file.FullName, FileMode.Open);
        XML.Deserialize(stream, ref currentCarDatabase);
        stream.Close();
    }
}
