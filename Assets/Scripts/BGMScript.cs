using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour {

    [SerializeField]
    AudioSource audioS;
    [SerializeField]
    AudioClip ac1;
    [SerializeField]
    AudioClip ac2;

	// Use this for initialization
	void Start () {
        audioS = GetComponent<AudioSource>();
        audioS.clip = ac1;
	}
	
	// Update is called once per frame
	void Update () {
        if (!audioS.isPlaying) {
            audioS.clip = ac2;
            audioS.loop = true;
            audioS.Play();
        }
	}
}
