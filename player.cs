using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Username - String
    public string username;

    // Level Progression - Integer
    public int levelProgression = 1;

    // Key Tracker - Bool 
    public bool key = false;

    // Coins Total - Integer
    public int coins = 0;

    // Scoreboard - Scoreboard Class
    public scoreBoard sb;

    // Start is called before the first frame update
    void Start()
    {
        // Set usernamer in Scoreboard
        sb.username = username;
    }

    // Update is called once per frame
    void Update()
    {

        // If user has >= 30 points - Call Set Key Status
        if (sb.score >= 30 && key == false) {

            setKeyStatus();

        }

        // If user presses K - Get key status
        if (Input.GetKeyDown(KeyCode.K))
        {
            getKeyStaus();
        }

        // If user presses R - Reset the coins to 0 and set key to false
        if (Input.GetKeyDown(KeyCode.R))
        {
            coins = 0;
            key = false;
        }


    }

    // Get Key Status - Debug if player has key
    void getKeyStaus()
    {

        if (key == true)
        {
            Debug.Log("The player DOES have the key");
        }
        else {
            Debug.Log("The player DOES NOT have the key");
        }

    }

    // Set Key Status - Set key to true or false
    void setKeyStatus() {

        Debug.Log("Changing Key staus to true! Player has the key");
        key = true;

    }

    // Get Coins - Debug the coins total
    void getCoins() {

        // Report the coins value
        Debug.Log("Play has: " + coins + " Coins");
    }

    // Set Coins - Add one to the coin total
    void setCoins()
    {
        coins += 1;

    }


}
