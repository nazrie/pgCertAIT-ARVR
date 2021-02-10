using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteraction : MonoBehaviour
{

    // Player Class Reference
    public player player;

    // Door Reference
    public GameObject door;

    // Door State - if its false, door is closed, if its true Door is open
    public bool doorState = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check The Key Satus From the Player Reference! 
    bool CheckKeyStatus() {
        // Return the Player Key status

        return true; // Raplace this with reference to player key
    }

    // Open the door
    void OpenDoor() {
        // IF the player has they Key
            // Open the Door By Setting Active True!

       
    }

    // Close the Door
    void CloseDoor() {

    }


}
