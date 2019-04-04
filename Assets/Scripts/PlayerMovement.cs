using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float groundSpeed = 7f;
    [SerializeField]
    float airSpeed = 1f;
    [SerializeField]
    float jumpForce = 3f;
    [SerializeField]
    bool canJump = true;

	// Use this for initialization
	void Awake () {
        if (!rb) {
            rb = GetComponent<Rigidbody>();
        }
	}

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) {
            if (canJump)
            {
                rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * groundSpeed);
            }
            else {
                rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * airSpeed);
            }
        }

        if (canJump) {
            if (Input.GetAxis("Vertical") > 0)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (GetDirectionOfCollision(collision) == Vector3.down)
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GetDirectionOfCollision(collision) == Vector3.down) {
            canJump = true;
        }
    }


    private Vector3 GetDirectionOfCollision(Collision collision)
    {
        Vector3 direction = (collision.transform.position - transform.position);
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycast;
        Physics.Raycast(ray, out raycast);
        
        if (raycast.collider)
        {
            Vector3 normal = raycast.normal;
            normal = raycast.transform.TransformDirection(normal);
            if (normal == raycast.transform.up)
            {
                return Vector3.down;
            }
            if (normal == -raycast.transform.up)
            {
                return Vector3.up;
            }
            if (normal == raycast.transform.right)
            {
                return Vector3.left;
            }
            if (normal == -raycast.transform.right)
            {
                return Vector3.right;
            }
        }
        return Vector3.zero;
    }
}
