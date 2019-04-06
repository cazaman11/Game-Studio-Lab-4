using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

    Scene currentScene;

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("SampleScene");
        //Mainmenu
    }
	
	// Update is called once per frame
	void Update () {
        currentScene = SceneManager.GetActiveScene();
		if(currentScene.name == "GameScene")
        {
            if(Input.GetKeyDown(KeyCode.R) )
            {
                restartGame();
            }
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("GameScene");
        }
	}

    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Scene reset");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
