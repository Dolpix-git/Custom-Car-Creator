using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CarXMLGenerator))]
public class CarXMLEditor : Editor{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        CarXMLGenerator myScript = (CarXMLGenerator)target;
        if (GUILayout.Button("Build/Save XML File")){
            myScript.SaveXMLFile();
        }
        if (GUILayout.Button("Load XML File From Name")){
            myScript.LoadXMLFile();
        }
    }
}
