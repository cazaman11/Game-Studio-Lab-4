using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        endGame();
    }

    void endGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
