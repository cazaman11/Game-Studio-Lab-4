using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondScript : MonoBehaviour {

    AudioSource audioS;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") {
            audioS.Play();
            endGame();
        }
    }

    void endGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
