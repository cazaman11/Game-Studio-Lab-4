using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour {

    [SerializeField]
    AudioSource audio;
    [SerializeField]
    AudioClip ac1;
    [SerializeField]
    AudioClip ac2;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        audio.clip = ac1;
	}
	
	// Update is called once per frame
	void Update () {
        if (!audio.isPlaying) {
            audio.clip = ac2;
            audio.loop = true;
            audio.Play();
        }
	}
}
