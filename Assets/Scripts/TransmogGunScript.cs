using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TransmogGunScript : MonoBehaviour {

    private Vector2 mousePos;
    public GameObject rockPrefab;
    public GameObject quicksandPrefab;
    public GameObject soilPrefab;
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
        clickDetect();
	}

    void soil()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Vector2 tempPos = hit.collider.gameObject.transform.position;

                if (hit.collider.gameObject.tag == "Background")
                {
                    Destroy(hit.collider.gameObject);
                    Instantiate(soilPrefab, tempPos, transform.rotation);
                }
            }
        }
    }

    void rock()
    {        
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Vector2 tempPos = hit.collider.gameObject.transform.position;

                if (hit.collider.gameObject.tag == "Background")
                {
                    Destroy(hit.collider.gameObject);
                    Instantiate(rockPrefab, tempPos, transform.rotation);
                }
            }        
    }

    void quicksand()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null)
        {
            Vector2 tempPos = hit.collider.gameObject.transform.position;

            if (hit.collider.gameObject.tag == "Background")
            {
                Destroy(hit.collider.gameObject);
                Instantiate(quicksandPrefab, tempPos, transform.rotation);
            }
        }
    }

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
        //clickSwapped = GameObject.Find("SwapClicksToggle").GetComponent<Toggle>().isOn;
    }
    
}
