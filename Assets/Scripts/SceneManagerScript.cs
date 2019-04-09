using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

    Scene currentScene;
    public bool seenBefore = false;
	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("MainMenuScene");
        //Mainmenu
    }
	
	// Update is called once per frame
	void Update () {
        currentScene = SceneManager.GetActiveScene();
		if(currentScene.name == "Alex's Scene")
        {
            if(Input.GetKeyDown(KeyCode.R) )
            {
                restartGame();
            }
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Alex's Scene");
        }

        /*
        if(Input.GetKeyDown(KeyCode.T))
        {
            toSampleScene();
        }
        */
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Alex's Scene");
        Debug.Log("Scene reset");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void toSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
