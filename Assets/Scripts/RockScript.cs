using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

    bool isFalling = false;
    [SerializeField]
    float tileSize = 0.32f;
    [SerializeField]
    Rigidbody rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isFalling) {
            if (CanFall())
            {
                isFalling = true;
                rb.useGravity = true;
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (isFalling) {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerMovement>().Damage();
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Ant")
            {
                collision.gameObject.GetComponent<AntController>().Die();
            }
            else if (collision.gameObject.tag == "Quicksand")
            {
                Destroy(collision.gameObject);
            }
            else {
                isFalling = false;
                rb.useGravity = false;
            }
        }
    }

    bool CanFall() {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.distance > tileSize || hit.transform == null)
        {
            return true;
        }
        return false;
    }

}
