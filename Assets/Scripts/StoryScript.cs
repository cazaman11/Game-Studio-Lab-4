using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour {

    bool seenBefore;
	// Use this for initialization
	void Start () {
        seenBefore = GameObject.Find("manager").GetComponent<SceneManagerScript>().seenBefore;
	}
	
	// Update is called once per frame
	void Update () {
		if(seenBefore)
        {
            gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            GameObject.Find("manager").GetComponent<SceneManagerScript>().seenBefore = true;
            gameObject.SetActive(false);
        }
	}
}
