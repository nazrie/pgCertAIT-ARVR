using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class workshopOne : MonoBehaviour
{

    // Username - String Value
    public string username = "Conor";

    // Score - Decimal Value Therefore Float or Double
    float score = 0;

    // Multiplier - Int
    float multiplier = 0;

    // Start Time - Date Time Format
    DateTime localDate;

    string m_Path;

    StreamWriter playerLog;



    // Start is called before the first frame update
    void Start()
    {
        localDate = DateTime.Now;

        // Create the File for Logging User Interaction
        playerLog = new StreamWriter(Application.dataPath + "/" + username + ".txt", true);


    }

    // Update is called once per frame
    void Update()
    {



        // Add points Using Keyboard Press A
        if (Input.GetKeyDown(KeyCode.A)) {
            addPoints();
        }




        // Reset Points using R Key on Keyboartd
        if (Input.GetKeyDown(KeyCode.D)) {

            resetPoints();

        }


        // Reset Points using R Key on Keyboartd
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Input.GetKeyDown(KeyCode.M))
            {
                resetMultiplier();
            }

        }




    }



    ////  Add Points Method – Add Score total + Consider Multiplier.
    void addPoints() {

        // Multplier
        float x = multiplyPoint();
        Debug.Log("Multiplier Value: " + x);

        // Add Points to Score 
        score = score + 1 + x;

        // Display in Unity
        Debug.Log("Score: " + score);

        // Get Time Now
        DateTime currentTime = DateTime.Now;

        // Construct Data for Log
        string data = currentTime.ToString() + ", " + 
                        "Adding Points! " + ", " + 
                        username + ", " + 
                        score + ", " + 
                        x;

        // Write Log to File
        playerLog.WriteLine(data);



    }


    //// Reduce Points - Reset the Points and Multiplier
    void resetPoints() {

        // Reset the Score to 0
        score = 0;

        // Reset The muliplier to 0
        multiplier = 0;

        Debug.Log("Score Reset!");

        // Get Time Now
        DateTime currentTime = DateTime.Now;

        // Construct Data for Log
        string data = currentTime.ToString() + ", " +
                        "Resetting Points! " + ", " +
                        username + ", " +
                        score + ", " +
                        multiplier;

        // Write Log to File
        playerLog.WriteLine(data);

    }


    void resetMultiplier() {

        multiplier = 0;

        // Get Time Now
        DateTime currentTime = DateTime.Now;

        // Construct Data for Log
        string data = currentTime.ToString() + ", " +
                        "Restting Multiplier! " + ", " +
                        username + ", " +
                        score + ", " +
                        multiplier;

        // Write Log to File
        playerLog.WriteLine(data);


    }




    //// Points Multiplier - Calculate 
    float multiplyPoint() {

        // Increase the Multiplier
        multiplier += 1;
        // Calculate the Muliplier
        float myTotal = multiplier * 0.25F;
        // Return the value
        return myTotal;

    }






    //// Save Score  - OnApplicationQuit()
    void saveScore() {

        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);

        // Open a File
        StreamWriter writer = new StreamWriter(m_Path + "/finalScore.txt", true);

        // End Time 
        DateTime endTime = DateTime.Now;

        // Generate Save String - start time, end time, username, score
        string data = localDate.ToString() + ", " +
                        endTime.ToString() + ", " +
                        username + ", " +
                        score;

        // Debug data Log
        Debug.Log(data);

        // Write to File
        writer.WriteLine(data);

        // Close a File
        writer.Close();

    }



    void OnApplicationQuit() {

        // Run Save Score to log start and stop time
        saveScore();

        // Close Player Log File
        playerLog.Close();

    }

}
