using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicksandScript : MonoBehaviour {

    bool isFalling = false;
    [SerializeField]
    float tileSize = 0.32f;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    GameObject quicksand;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (isFalling)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerMovement>().Stuck();
            }
            else if (collision.gameObject.tag == "Ant")
            {
                collision.gameObject.GetComponent<AntController>().Stuck();
            }
            else if (collision.gameObject.tag == "Rock")
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Dirt")
            {
                Vector3 pos = collision.transform.position;
                Destroy(collision.gameObject);
                Instantiate(quicksand, pos, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    bool CanFall()
    {
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
