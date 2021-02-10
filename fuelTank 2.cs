using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelTank : MonoBehaviour
{
    // Set the Tank to 50
    public float fuel = 50.00F; 




    // Start is called before the first frame update
    void Start()
    {
        // Repeat a task automatically
        InvokeRepeating("fuelUsage", 0F, 0.1F);
        InvokeRepeating("fuelRemaining", 0F, 5F);
    }



    // Calculate the Fuel Usage and Reduce the Fuel Automatically
    void fuelUsage() {

        // Drop the Fuel if its greater than 0
        if (fuel > 0)
        {
            // Reduce the fuel by 0.1F (F=Float)
            fuel -= 0.1F;
        }
    }

    // Display the Fuel Every 5 seconds
    void fuelRemaining()
    {
        // Display the message
        Debug.Log("Current Fuel Remaining: " + System.Math.Round(fuel,2));

    }


}
