using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TransmogGunScript : MonoBehaviour {

    private Vector3 mousePos;
    /*public Tilemap tilemap;
    private Vector3Int tilePos;
    private TileBase selectedTile;
    private Tile tile;
    private Sprite selectedSprite;
    private TileData tileData;
    private ITilemap iTileMap;
    private ITilemap iTileMap;*/
    [SerializeField]
    bool clickSwapped = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        swapClicks();
        soil();
        //rock();
        //quicksand();
        clickDetect();
	}

    void soil()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            mousePos = Input.mousePosition;
            Debug.Log("mousePos" + mousePos);
        }
    }

    void rock()
    {
        mousePos = Input.mousePosition;
        Debug.Log("mousePos" + mousePos);
        Debug.Log("Rock click");
    }

    void quicksand()
    {
            mousePos = Input.mousePosition;
            Debug.Log("mousePos" + mousePos);
            Debug.Log("Quicksand click");      
    }

    /*void getTile()
    {
        tilePos = Vector3Int.FloorToInt(mousePos);
        Debug.Log("tilePos = " + tilePos);
        selectedTile = tilemap.GetTile(tilePos);
        selectedTile.GetTileData(tilePos, iTileMap, ref tileData);
        selectedSprite = tileData.sprite;

        
        //selectedSprite = tilemap.GetSprite(tilePos);
        Debug.Log("selectedSprite = " + selectedSprite);
    }*/

    void clickDetect()
    {
        if (Input.GetMouseButtonUp(0) && clickSwapped == false)
        {
            rock();
        }
        else if (Input.GetMouseButtonUp(0) && clickSwapped == true)
        {
            quicksand();
        }

        if (Input.GetMouseButtonUp(1) && clickSwapped == false)
        {
            quicksand();
        }
        else if (Input.GetMouseButtonUp(1) && clickSwapped == true)
        {
            rock();
        }
    }

    public void swapClicks()
    {
        //clickSwapped = !clickSwapped;
        clickSwapped = GameObject.Find("SwapClicksToggle").GetComponent<Toggle>().isOn;
    }
    
}
