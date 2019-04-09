using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmogScript : MonoBehaviour {

    Vector2 mousePos;
    [SerializeField]
    GameObject quicksand;
    [SerializeField]
    GameObject rock;
    [SerializeField]
    GameObject background;

    enum GunState { Quicksand, Rock };
    GunState currState = GunState.Rock;

	// Use this for initialization
	void Start () {
        currState = GunState.Rock;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (currState == GunState.Rock) currState = GunState.Quicksand;
            else currState = GunState.Rock;
        }
        if (Input.GetMouseButtonDown(1)) {
            if (currState == GunState.Rock) SwitchBlock(rock);
            else SwitchBlock(quicksand);
        }
        if (Input.GetMouseButtonDown(0)) {
            SwitchBlock(background);
        }
	}

    void SwitchBlock(GameObject pref) {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos3D = new Vector3(mousePos.x, mousePos.y, -1f);
        RaycastHit hit;
        Physics.Raycast(mousePos3D, Vector3.forward, out hit, 1);
        if (hit.collider)
        {
            if (hit.collider.tag == "Dirt") {
                Vector3 tempPos = hit.collider.transform.position;
                Destroy(hit.collider.gameObject);
                Instantiate(pref, tempPos, Quaternion.identity);
            }
        }
    }
}
