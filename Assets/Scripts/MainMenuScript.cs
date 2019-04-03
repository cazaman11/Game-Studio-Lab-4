using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    Button startButton;
    Button tutorialButton;
    Button quitButton;
    GameObject tutorial;
    // Use this for initialization
    void Start () {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(startGame);
        tutorialButton = GameObject.Find("TutorialButton").GetComponent<Button>();
        tutorialButton.onClick.AddListener(tutorialScreen);
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(quit);

        tutorial = GameObject.Find("Tutorial");
        tutorial.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void startGame()
    {
        GameObject.Find("manager").GetComponent<SceneManagerScript>().restartGame();
    }

    void tutorialScreen()
    {
        tutorial.SetActive(!tutorial.activeSelf);
    }

    void quit()
    {
        Application.Quit();
    }
}
