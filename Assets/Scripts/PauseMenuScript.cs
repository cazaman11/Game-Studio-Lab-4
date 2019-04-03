using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenuScript : MonoBehaviour {
    [SerializeField]
    Button resumeButton;
    Button restartButton;
    Button exitButton;
    bool paused = false;
    // Use this for initialization
    void Start () {
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        resumeButton.onClick.AddListener(resumeGame);
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(restartGame);
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(exitGame);
    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            if (paused)
            {
                pauseGame();
            }
            else if (paused == false)
            {
                resumeGame();
            }
        }

        Debug.Log(paused);
	}


    void pauseGame()
    {
        Time.timeScale = 0f;
        //prevent player input and maybe enemy stuff
        gameObject.GetComponent<Canvas>().enabled = true;
    }

    void resumeGame()
    {
        Time.timeScale = 1f;
        //allow player control
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    void restartGame()
    {
        GameObject.Find("manager").GetComponent<SceneManagerScript>().restartGame();
    }

    void exitGame()
    {
        GameObject.Find("manager").GetComponent<SceneManagerScript>().mainMenu();
    }
}
