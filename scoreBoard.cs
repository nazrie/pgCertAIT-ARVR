using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour
{

    // Username - String Value
    public string username = "No Username";

    // Score - Decimal Value Therefore Float or Double
    float score = 0;

    // Multiplier - Int
    float multiplier = 0;

    // Start Time - Date Time Format
    DateTime localDate;

    // Application Path Variable
    string m_Path;

    // Log for the Player
    StreamWriter playerLog;

    //// GUI ////
    // GUI Score
    public Text guiScoreText;

    // GUI Multiplier
    public Text guiMultilipier;



    // Start is called before the first frame update
    void Start()
    {
        // Get current Date and Time
        localDate = DateTime.Now;

        // Create the File for Logging User Interaction
        playerLog = new StreamWriter(Application.dataPath + "/" + username + "_gameLog.txt", true);

    }

    // Update is called once per frame
    void Update()
    {

        // Add points Using Keyboard Press A
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Call the Add Points Method
            addPoints();

            // Call the Update GUI Method
            UpdateGUI();

        }




        // Reset Points using R Key on Keyboartd
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Call the Reset Method
            resetPoints();

            // Call the Update GUI Method
            UpdateGUI();

        }


        // The left shift button is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // The M button us pressed
            if (Input.GetKeyDown(KeyCode.M))
            {
                // Reset Multiplier
                resetMultiplier();

                // Update the GUI
                UpdateGUI();
            }

        }

    }


    void UpdateGUI()
    {
        try
        {
            Debug.Log("Updating GUI!");
            guiScoreText.text = "Score: " + score.ToString();
            guiMultilipier.text = "Multiplier: " + multiplier.ToString();
        }
        catch (Exception e) {
            // Display Error
            Debug.Log("------- WARNING: GUI may not be configured! -------");

            // Display full error - NB: Disabled for now
            // Debug.Log(e);

        }

    }



    ////  Add Points Method – Add Score total + Consider Multiplier.
    void addPoints()
    {

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
    void resetPoints()
    {

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


    void resetMultiplier()
    {

        multiplier = 0;

        // Get Time Now
        DateTime currentTime = DateTime.Now;

        // Construct Data for Log
        string data = currentTime.ToString() + ", " +
                        "Resetting Multiplier! " + ", " +
                        username + ", " +
                        score + ", " +
                        multiplier;

        // Write Log to File
        playerLog.WriteLine(data);


    }




    //// Points Multiplier - Calculate 
    float multiplyPoint()
    {

        // Increase the Multiplier
        multiplier += 1;

        // Calculate the Muliplier
        float myTotal = multiplier * 0.25F;

        // Return the value
        return myTotal;

    }






    // Save the total Score on the leaderboard
    void saveScore()
    {

        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);

        // Open a File
        StreamWriter writer = new StreamWriter(m_Path + "/leaderboard.txt", true);

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


    // When the application shuts down - do something
    void OnApplicationQuit()
    {

        // Run Save Score to log start and stop time
        saveScore();

        // Close Player Log File
        playerLog.Close();

    }

}
