using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentCar : MonoBehaviour{
    public float totalCost;

    public int car;

    public int modelTypes;
    public int paint;
    public int wheels;
    public int towHitch;
    public int interior;
    public int seatingLayout;
    public int enhancedAutoPilot;
    public int FSD;

    public CarData carData;
    public GameObject mainScreen;
    public GameObject finalScreen;
    public TextMeshProUGUI recipt;

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            RefreshTotalCost();
        }
        if (Input.GetKeyDown(KeyCode.W)){
            SetDefaultValues(0);
        }
    }
    public void ShowEndScreen(){
        carData.Data[car].uiOptions.SetActive(false);
        finalScreen.SetActive(true);

        string endText = "Thank you for buying! \n\n\n";


        endText += carData.Data[car].modelTypes[modelTypes].tag + "\n" + "Total Cost: "+ totalCost.ToString("n2") +"\n\n";

        if (carData.Data[car].paint.Length != 0 && paint != -1)
        {
            endText += carData.Data[car].paint[paint].tag + "\n";
        }
        if (carData.Data[car].wheels.Length != 0 && wheels != -1)
        {
            endText += carData.Data[car].wheels[wheels].tag + "\n";
        }
        if (carData.Data[car].towHitch.Length != 0 && towHitch != -1)
        {
            endText += carData.Data[car].towHitch[towHitch].tag + "\n";
        }
        if (carData.Data[car].interior.Length != 0 && interior != -1)
        {
            endText += carData.Data[car].interior[interior].tag + "\n";
        }
        if (carData.Data[car].seatingLayout.Length != 0 && seatingLayout != -1)
        {
            endText += carData.Data[car].seatingLayout[seatingLayout].tag + "\n";
        }
        if (carData.Data[car].enhancedAutoPilot.Length != 0 && enhancedAutoPilot != -1)
        {
            endText += carData.Data[car].enhancedAutoPilot[enhancedAutoPilot].tag + "\n";
        }
        if (carData.Data[car].FSD.Length != 0 && FSD != -1)
        {
            endText += carData.Data[car].FSD[FSD].tag + "\n";
        }


        recipt.text = endText;
    }

    public void GoToMainMenu(){
        carData.Data[car].uiOptions.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void CloseEndScreen(){
        finalScreen.SetActive(false);
    }

    public void SetDefaultValues(int c){

        mainScreen.SetActive(false);

        carData.Data[car].carWithNoWheels.SetActive(false);
        carData.Data[car].uiOptions.SetActive(false);
        for (int i = 0; i < carData.Data[car].wheels.Length; i++){
            carData.Data[car].wheels[i].wheel.SetActive(false);
        }  


        car = c;


        carData.Data[car].carWithNoWheels.SetActive(true);
        carData.Data[car].uiOptions.SetActive(true);
        totalCost = 0;
        modelTypes = 0;
        paint = 0;
        wheels = 0;
        carData.Data[car].wheels[0].wheel.SetActive(true);
        towHitch = -1;
        interior = 0;
        seatingLayout = 0;
        enhancedAutoPilot = -1;
        FSD = -1;

        carData.Data[car].carPaint.color = carData.Data[car].paint[paint].color;
        carData.Data[car].interiorPaint.color = carData.Data[car].interior[interior].color;

        RefreshTotalCost();
    }

    public void RefreshTotalCost(){
        totalCost = 0;


        for (int i = 0; i < carData.Data[car].wheels.Length; i++){
            carData.Data[car].wheels[i].wheel.SetActive(false);
        }
        carData.Data[car].wheels[wheels].wheel.SetActive(true);

        carData.Data[car].carPaint.color = carData.Data[car].paint[paint].color;
        carData.Data[car].interiorPaint.color = carData.Data[car].interior[interior].color;

        if (carData.Data.Length == 0){
            return;
        }
        if (carData.Data[car].modelTypes.Length != 0 && modelTypes != -1){
            totalCost += carData.Data[car].modelTypes[modelTypes].cost;
        }
        if (carData.Data[car].paint.Length != 0 && paint != -1)
        {
            totalCost += carData.Data[car].paint[paint].cost;
        }
        if (carData.Data[car].wheels.Length != 0 && wheels != -1)
        {
            totalCost += carData.Data[car].wheels[wheels].cost;
        }
        if (carData.Data[car].towHitch.Length != 0 && towHitch != -1)
        {
            totalCost += carData.Data[car].towHitch[towHitch].cost;
        }
        if (carData.Data[car].interior.Length != 0 && interior != -1)
        {
            totalCost += carData.Data[car].interior[interior].cost;
        }
        if (carData.Data[car].seatingLayout.Length != 0 && seatingLayout != -1)
        {
            totalCost += carData.Data[car].seatingLayout[seatingLayout].cost;
        }
        if (carData.Data[car].enhancedAutoPilot.Length != 0 && enhancedAutoPilot != -1)
        {
            totalCost += carData.Data[car].enhancedAutoPilot[enhancedAutoPilot].cost;
        }
        if (carData.Data[car].FSD.Length != 0 && FSD != -1)
        {
            totalCost += carData.Data[car].FSD[FSD].cost;
        }


        carData.Data[car].price.text = "Total Price: " + totalCost.ToString("n");
        Debug.Log(totalCost);
    }

    public void PrintRecept(){
        Debug.Log(carData.Data[0]);
    }

    public void SetModelType(int i)
    {
        modelTypes = i;
        RefreshTotalCost();
    }
    public void SetPaint(int i)
    {
        paint = i;
        RefreshTotalCost();
    }
    public void SetWheels(int i)
    {
        wheels = i;
        RefreshTotalCost();
    }
    public void SetTowwHitch(Toggle i)
    {
        if (i.isOn){
            towHitch = 0;
        }
        else
        {
            towHitch = -1;
        }
        
        RefreshTotalCost();
    }    
    public void SetInterior(int i)
    {
        interior = i;
        RefreshTotalCost();
    }
    public void SetSeatingLayout(int i)
    {
        seatingLayout = i;
        RefreshTotalCost();
    }
    public void SetEnchancedAutoPilot(Toggle i)
    {
        if (i.isOn)
        {
            enhancedAutoPilot = 0;
        }
        else
        {
            enhancedAutoPilot = -1;
        }
        RefreshTotalCost();
    }
    public void SetFSD(Toggle i)
    {
        if (i.isOn)
        {
            FSD = 0;
        }
        else
        {
            FSD = -1;
        }
        RefreshTotalCost();
    }
}
