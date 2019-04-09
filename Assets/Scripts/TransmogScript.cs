using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmogScript : MonoBehaviour
{

    Vector2 mousePos;
    [SerializeField]
    GameObject quicksand;
    [SerializeField]
    GameObject rock;
    [SerializeField]
    GameObject background;
    [SerializeField]
    float tileSize = 0.32f;

    enum GunState { Quicksand, Rock };
    GunState currState = GunState.Rock;

    // Use this for initialization
    void Start()
    {
        currState = GunState.Rock;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currState == GunState.Rock) currState = GunState.Quicksand;
            else currState = GunState.Rock;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (currState == GunState.Rock) SwitchBlock(rock);
            else SwitchBlock(quicksand);
        }
        if (Input.GetMouseButtonDown(0))
        {
            SwitchBlock(background);
        }
    }

    void SwitchBlock(GameObject pref)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos3D = new Vector3(mousePos.x, mousePos.y, -1f);
        if (InRange(mousePos3D))
        {
            RaycastHit hit;
            Physics.Raycast(mousePos3D, Vector3.forward, out hit, 1);
            if (hit.collider)
            {
                if (hit.collider.tag == "Dirt")
                {
                    Vector3 tempPos = hit.collider.transform.position;
                    Destroy(hit.collider.gameObject);
                    if (pref.tag != "Background")
                    {
                        Instantiate(pref, tempPos, Quaternion.identity);
                    }
                    Instantiate(background, tempPos, Quaternion.identity);
                }
            }
        }
    }

    bool InRange(Vector3 pos)
    {
        float upperXBounds = transform.position.x + tileSize;
        float lowerXBounds = transform.position.x - tileSize;
        float upperYBounds = transform.position.y + tileSize;
        float lowerYBounds = transform.position.y - tileSize;
        if (pos.x > upperXBounds)
        {
            return false;
        }
        if (pos.x < lowerXBounds)
        {
            return false;
        }
        if (pos.y > upperYBounds)
        {
            return false;
        }
        if (pos.y < lowerYBounds)
        {
            return false;
        }
        return true;
    }
}
