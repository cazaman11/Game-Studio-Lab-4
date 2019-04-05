using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransmogGunScript : MonoBehaviour {

    private Vector3 mousePos;
    public Tilemap tilemap;
    private Vector3Int tilePos;
    private TileBase selectedTile;
    private Tile tile;
    private Sprite selectedSprite;
    private TileData tileData;
    private ITilemap iTileMap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        soil();
        rock();
        quicksand();

	}

    void soil()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            mousePos = Input.mousePosition;
            Debug.Log("mousePos" + mousePos);
            getTile();
        }
    }

    void rock()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mousePos = Input.mousePosition;
            Debug.Log("mousePos" + mousePos);
            getTile();
        }
    }

    void quicksand()
    {
        if (Input.GetMouseButtonUp(1))
        {
            mousePos = Input.mousePosition;
            Debug.Log("mousePos" + mousePos);
            getTile();
        }
    }

    void getTile()
    {
        tilePos = Vector3Int.FloorToInt(mousePos);
        Debug.Log("tilePos = " + tilePos);
        selectedTile = tilemap.GetTile(tilePos);
        selectedTile.GetTileData(tilePos, iTileMap, ref tileData);
        selectedSprite = tileData.sprite;

        
        //selectedSprite = tilemap.GetSprite(tilePos);
        Debug.Log("selectedSprite = " + selectedSprite);
    }

    

    
}
