using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MuteScript : MonoBehaviour {

    Image image;
    [SerializeField]
    Sprite notMuteSprite;
    [SerializeField]
    Sprite muteSprite;
    Button muteButton;
    bool paused = false;

	// Use this for initialization
	void Start () {
        image = GameObject.Find("MuteButton").GetComponent<Image>();
        muteButton = GameObject.Find("MuteButton").GetComponent<Button>();
        muteButton.onClick.AddListener(toggleMute);
	}

    void toggleMute()
    {
        paused = !paused;
        AudioListener.pause = paused;
        Debug.Log(paused);
        if (paused)
        {
            image.sprite = muteSprite;
        }
        else
            image.sprite = notMuteSprite;
    }
}
