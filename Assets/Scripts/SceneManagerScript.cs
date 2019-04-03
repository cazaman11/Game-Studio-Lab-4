using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
                Debug.Log("Scene reset");
            }
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("GameScene");
        }
	}
}
