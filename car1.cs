using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Nazrie Abu Seman 2020 
// Practical Exam part 1

public class car : MonoBehaviour
{


    // Creating Variables
    // Car make variable
    public string carMake = "Audi";

    // Car model variable
    public string carModel = "RS5";

    // Car colour variable. Default value is black
    public string carColour = "Black";

    // Car lights variable. By default is set to false. Made it public so it can be seen in the UI when the code runs.
    public bool carLights = false;

    // Car maximum speed limit 
    public int carMaxSpeed = 120;

    // Car current speed variable.
    public int carCurrentSpeed = 0;    

    public fuelTank ft;

    // Start is called before the first frame update
    void Start()
    {
        // check the current speed at the beginning of the frame.
        Debug.Log($"Car start speed: {carCurrentSpeed}");

    }

    // Update is called once per frame
    void Update()
    {

        // IF statement to monitor for any key presses to update the appropriate method. 
        // Run the accelerate method

        if (carCurrentSpeed >= 0 && carCurrentSpeed <= carMaxSpeed){

            if (Input.GetKey(KeyCode.W)){
                Debug.Log("The car is accelerating."); 
                Accelerate();    
                TurnLightsOn(); 

                if (carCurrentSpeed == carMaxSpeed) {
                    Debug.Log("Max Speed Achieved!");
                }
            } 
        }
            
            // Run the brakes method and check condition based on the current speed.
            if  (Input.GetKey(KeyCode.S)){           
                Brakes(); 
                Debug.Log("Brakes applied");
                
                
                if (carCurrentSpeed <= 0) {
                    Debug.Log("The car is already stopped");
                    TurnLightsOff();
                }
            } 
        
        // Calling the check fuel method
        if (Input.GetKeyDown(KeyCode.F))    {
            
            Debug.Log($"You're driving a {carMake} - {carModel} at a speed of: {carCurrentSpeed}kph. The car top speed is {carMaxSpeed}kph.");

        }
        
        // Display information about the car make, model and top speed.
        if (Input.GetKey(KeyCode.I))    {
            
            Debug.Log($"You're driving a {carMake} - {carModel} at a speed of: {carCurrentSpeed}kph. The car top speed is {carMaxSpeed}kph.");

        }

    }

    /// Accelerate method > update the current speed of the car. 
    // Every time called, add 10 to the current speed.
    void Accelerate(){
        
        if (ft.fuel > 0){
            carCurrentSpeed += 10;
            Debug.Log("Speed increased: Current speed is "+ carCurrentSpeed);
        }
        
        if(ft.fuel < 0){
            Brakes();
        }
       
    }


    /// Brakes method > when the method is called, minus the speed by 15.
    // IF the current speed less < 0; set the current speed to 0.
    void Brakes(){
        carCurrentSpeed -= 15;
        Debug.Log("Speed decreased: Current speed is "+ carCurrentSpeed);

            if (carCurrentSpeed < 0){
                carCurrentSpeed = 0;
            }
    }


    /// TurnLightsOn method > Set the light to ON state
    // Print "The lights are turned on"
    void TurnLightsOn() {
        carLights = true;
        Debug.Log("The lights are turned ON");
}
    
    /// TurnLightsOff method > Set the light to OFF state
    // Print "The lights are turned off".
    void TurnLightsOff() {
        carLights = false;
        Debug.Log("The lights are turned OFF");
    }

    /// CheckFuelLevel method to check the fuel stored in fueltank class.
    //  Checking if fuel less than 20 and if fuel is 0.

    void CheckFuelLevel(){

        if (ft.fuel < 20){
            Debug.Log("Low Fuel Warning!");
        }

        if (ft.fuel == 0){
            Debug.Log("No Fuel Remaining");
        }

    }





}
