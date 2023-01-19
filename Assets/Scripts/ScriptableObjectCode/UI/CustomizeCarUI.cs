using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCarUI : MonoBehaviour{
    [SerializeField] private CustomizedCar customCar;
    [SerializeField] private CarDataBaseManager carDataBaseManager;

    [SerializeField] private GameObject catagories;
    [SerializeField] private GameObject options, optionPrefab;

    [SerializeField] private TextMeshProUGUI costText;

    private List<GameObject> catagoriesGameobjects = new List<GameObject>();
    private List<GameObject> optionsGameobjects = new List<GameObject>();

    void Start(){
        GenCatagories();
        GenCarOptions();
        UpdateCost();
    }

    public void GenCatagories(){
        // remove everything
        foreach (GameObject catagory in catagoriesGameobjects){
            Destroy(catagory);
        }
        catagoriesGameobjects.Clear();

        // spawn car body catagory
        GameObject newPrefab = Instantiate(carDataBaseManager.catagoryDict[PartKeys.Body]);
        newPrefab.transform.SetParent(catagories.transform);
        newPrefab.name = "Body";
        catagoriesGameobjects.Add(newPrefab);
        newPrefab.GetComponent<Button>().onClick.AddListener(() => GenCarOptions());
        newPrefab.GetComponent<Button>().onClick.AddListener(() => UpdateCost());

        // based on current car spawn all the relevent catagories
        foreach (var key in customCar.carData.Keys){
            newPrefab = Instantiate(carDataBaseManager.catagoryDict[key]);
            newPrefab.transform.SetParent(catagories.transform);
            newPrefab.name = key.ToString();
            catagoriesGameobjects.Add(newPrefab);
            newPrefab.GetComponent<Button>().onClick.AddListener(() => GenOptions(key));
            newPrefab.GetComponent<Button>().onClick.AddListener(() => UpdateCost());
        }
    }


    public void GenOptions(PartKeys key){
        foreach (GameObject option in optionsGameobjects){
            Destroy(option);
        }
        optionsGameobjects.Clear();


        if (customCar.carModel.carParts.TryGetValue(key,out CarPart[] c)) {
            foreach (CarPart part in c){
                GameObject newPrefab = Instantiate(optionPrefab);
                newPrefab.transform.SetParent(options.transform);
                newPrefab.name = key.ToString();
                optionsGameobjects.Add(newPrefab);
                newPrefab.GetComponent<Button>().onClick.AddListener(() => customCar.ChangeCarPart(key, part));
                newPrefab.GetComponent<Button>().onClick.AddListener(() => UpdateCost());
                newPrefab.GetComponentInChildren<TextMeshProUGUI>().text = part.partName;
            }
        }

    }

    public void GenCarOptions(){
        // remove everything
        foreach (GameObject option in optionsGameobjects){
            Destroy(option);
        }
        optionsGameobjects.Clear();

        // loop through all the options avaliable for this catagory in the current car
        // make sure to assign the values for each button for car parts
        foreach (CarModel carmodel in carDataBaseManager.CarDataBase){
            GameObject newPrefab = Instantiate(optionPrefab);
            newPrefab.transform.SetParent(options.transform);
            newPrefab.name = carmodel.carName;
            optionsGameobjects.Add(newPrefab);
            newPrefab.GetComponent<Button>().onClick.AddListener(() => carDataBaseManager.LoadCar(carmodel));
            newPrefab.GetComponent<Button>().onClick.AddListener(() => UpdateCost());
            newPrefab.GetComponentInChildren<TextMeshProUGUI>().text = carmodel.carName;
        }
    }

    public void UpdateCost(){
        costText.text = customCar.RetrunPrice().ToString("n2");
    }
}
