using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUIScript : MonoBehaviour {

    
    GameObject thirdHeart;
    GameObject secondHeart;
    GameObject firstHeart;
    [SerializeField]
    int health = 3;
    // Use this for initialization
    void Start () {
        thirdHeart = GameObject.Find("3Heart");
        secondHeart = GameObject.Find("2Heart");
        firstHeart = GameObject.Find("1Heart");
       
    }

    // Update is called once per frame
    void Update () {
        //get hp from player script
        if (health == 2 || Input.GetKeyDown(KeyCode.A))
        {
            thirdHeart.SetActive(false);
            secondHeart.SetActive(true);
            firstHeart.SetActive(true);
        }
        if(health == 1 || Input.GetKeyDown(KeyCode.S))
        {
            thirdHeart.SetActive(false);
            secondHeart.SetActive(false);
            firstHeart.SetActive(true);
        }
        if(health == 0 || Input.GetKeyDown(KeyCode.D))
        {
            thirdHeart.SetActive(false);
            secondHeart.SetActive(false);
            firstHeart.SetActive(false);
        }
        if( Input.GetKeyDown(KeyCode.F))
        {
            fullHp();
        }

    }

    void fullHp()
    {
        thirdHeart.SetActive(true);
        secondHeart.SetActive(true);
        firstHeart.SetActive(true);
        health = 3;
    }
}
