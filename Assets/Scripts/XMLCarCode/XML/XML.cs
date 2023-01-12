using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XML{
    public static void Serialize(FileStream stream, Dictionary<string, List<CarObject>> dictionary){
        List<Car> entries = new List<Car>(dictionary.Count);
        foreach (string key in dictionary.Keys){
            List<CarObject> value = (List<CarObject>)dictionary[key];
            entries.Add(new Car(key, value));
        }
        XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
        serializer.Serialize(stream, entries);
    }
    public static void Deserialize(FileStream stream, ref Dictionary<string, List<CarObject>> dictionary){
        dictionary.Clear();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
        List<Car> list = (List<Car>)serializer.Deserialize(stream);
        foreach (Car entry in list){
            dictionary[entry.key] = entry.value;
        }
    }
    public static int FileCount(){
        string path = Application.dataPath + "/Cars/XML Data";
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles();

        int count = 0;

        foreach (var file in fileInfo){
            if (file.Extension == ".xml"){
                Debug.Log(file.Name);
                count++;
            }
        }

        return count;
    }
    public static FileInfo[] FileList(){
        string path = Application.dataPath + "/Cars/XML Data";
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles();

        List<FileInfo> files = new List<FileInfo>();

        foreach (var file in fileInfo){
            if (file.Extension == ".xml"){
                files.Add(file);
            }
        }

        return files.ToArray();
    }
}