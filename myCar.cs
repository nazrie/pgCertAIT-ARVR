using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class myCar : MonoBehaviour
{


    // Creating Variables
    // Car make variable
    public string carMake = "Audi";

    // Car model variable
    public string carModel = "RS5";

    // Car colour variable. Default value is black
    public string carColour = "Black";

    // Car lights variable. By default is set to false.
    public bool carLights = false;

    // Car maximum speed limit 
    int carMaxSpeed = 120;

    // Car current speed variable.
    int carCurrentSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        // IF statement to monitor for any key presses to update the appropriate method. 
        // Run the accelerate method
        if (Input.GetKeyDown(KeyCode.W))
        {
            Accelerate();
        }

        // Run the brakes method and check condition based on the current speed.
        if (Input.GetKeyDown(KeyCode.S))
        {
            Brakes();
            if (carCurrentSpeed <= 0)
            {
                Debug.Log("The car is already stopped");
            }
        }

        // Display information about the car make, model and top speed.
        if (Input.GetKeyDown(KeyCode.I))
        {

            Debug.Log($"You're driving a {carMake} - {carModel} at {carCurrentSpeed}, the top speed is {carMaxSpeed}");

        }
    }

    /// Accelerate method > update the current speed of the car. 
    // Every time called, add 10 to the current speed.
    void Accelerate()
    {
        carCurrentSpeed += 10;
    }


    /// Brakes method > when the method is called, minus the speed by 15.
    // IF the current speed less < 0; set the current speed to 0.
    void Brakes()
    {
        carCurrentSpeed -= 15;

        if (carCurrentSpeed < 0)
        {
            carCurrentSpeed = 0;
        }
    }


    /// TurnLightsOn method > Set the light to ON state
    // Print "The lights are turned on"
    void TurnLightsOn()
    {
        carLights = true;
        Debug.Log("The lights are turned ON");
    }

    /// TurnLightsOff method > Set the light to OFF state
    // Print "The lights are turned off".
    void TurnLightsOff() 
    {
        carLights = false;
        Debug.Log("The lights are turned OFF");
    }

}
