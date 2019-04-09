using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSwitchScript : MonoBehaviour {

    [SerializeField]
    Sprite rock;
    [SerializeField]
    Sprite quicksand;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchImage(string name) {
        if (name == "rock")
        {
            gameObject.GetComponent<Image>().sprite = rock;
        }
        else {
            gameObject.GetComponent<Image>().sprite = quicksand;
        }
    }
}
