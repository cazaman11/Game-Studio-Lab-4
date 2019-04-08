using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSoundScript : MonoBehaviour {
    AudioSource winSfx;

	// Use this for initialization
	void Start () {
        winSfx = GameObject.Find("testManager").GetComponent<AudioSource>();
	}
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player trigger");
            winSfx.Play();
        }
        Debug.Log("Colliding");
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player trigger");
            winSfx.Play();
        }
    }
}
