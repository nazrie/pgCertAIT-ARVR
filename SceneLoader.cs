using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton(buttonName: "Button-3-breathing"))
        {
            ChangeScene();
        }

        if (Input.GetButton("Button-TensionRelease"))
        {
            ChangeScene2();
        }

    }

    public void ChangeScene()
        {
            SceneManager.LoadScene("GreenNature");
        }


    public void ChangeScene2()
        {
           SceneManager.LoadScene("OpenSpaceSea");
        } 

    
}
