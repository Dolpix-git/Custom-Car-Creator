using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CarCustomizerManager : MonoBehaviour{
    [SerializeField] private GameObject carsPrefab;
    [SerializeField] private GameObject carsChoicePrefab;
    [SerializeField] private GameObject carChoicesScreen;
    [SerializeField] private GameObject carCustomScreen;
    [SerializeField] private TextMeshProUGUI priceText;


    private void Start(){
        DisplayCars();
    }

    public void DisplayCars(){
        carCustomScreen.transform.parent.gameObject.SetActive(false);
        carChoicesScreen.transform.parent.gameObject.SetActive(true);

        

        foreach (Transform child in carChoicesScreen.transform){
            Destroy(child.gameObject);
        }

        foreach (FileInfo keys in XML.FileList()){
            GameObject newPrefab = Instantiate(carsPrefab);
            newPrefab.transform.SetParent(carChoicesScreen.transform, false);
            newPrefab.name = keys.Name;
            newPrefab.GetComponentInChildren<TextMeshProUGUI>().text = keys.Name;

            newPrefab.GetComponent<Button>().onClick.AddListener(() => SetCurrentDataSet(keys));
        }
    }
    public void DisplayCarsChoices(){
        carCustomScreen.transform.parent.gameObject.SetActive(true);
        carChoicesScreen.transform.parent.gameObject.SetActive(false);

        SetDefaultValues();

        foreach (Transform child in carCustomScreen.transform){
            Destroy(child.gameObject);
        }

        foreach (string keys in CarXMLManager.Instance.currentCarDatabase.Keys){
            GameObject newPrefab = Instantiate(carsChoicePrefab);
            newPrefab.transform.SetParent(carCustomScreen.transform, false);
            newPrefab.name = keys;

            //Too Do: Add buttons linking to function


        }
    }


    public void SetCurrentCarObject(string key, int index){
        string newKey;
        CarObject newValue;

        List<CarObject> values;
        if (CarXMLManager.Instance.currentCarDatabase.TryGetValue(key, out values)){
            if (index > CarXMLManager.Instance.currentCarDatabase[key].Count){
                Debug.LogError("A button attempted to look for a value out of range of the current data set   Index: " + index + " List Length: " + CarXMLManager.Instance.currentCarDatabase[key].Count);
                return;
            }
            newKey = key;
            newValue = CarXMLManager.Instance.currentCarDatabase[key][index];
        }
        else{
            Debug.LogError("A button attempted to look for a non-exsistant key in the current data set  Key: " + key);
            return;
        }

        CarManager.Instance.AttemptReplace(newKey,newValue);

        priceText.text = CarManager.Instance.GetTotalCost().ToString("n2") + " $";
    }
    public void SetDefaultValues(){
        CarManager.Instance.ResetCarData();

        foreach (var key in CarXMLManager.Instance.currentCarDatabase.Keys){
            CarManager.Instance.AddObject(key, CarXMLManager.Instance.currentCarDatabase[key][0]);
        }

        priceText.text = CarManager.Instance.GetTotalCost().ToString("n2") + " $";

        Debug.Log("Loaded Data Set");
    }

    public void SetCurrentDataSet(FileInfo i){
        Debug.Log("TEST");
        CarXMLManager.Instance.ChooseDatabase(i);
        DisplayCarsChoices();
    }
}
