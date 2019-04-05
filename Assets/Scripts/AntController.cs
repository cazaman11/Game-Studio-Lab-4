using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour {

    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Collider coll;
    [SerializeField]
    float groundSpeed = 7f;
    [SerializeField]
    float digSpeed = 0.001f;
    bool canMove = false;
    bool burried = true;
    Vector3 dirOfOpening = Vector3.zero;
    Vector3 startPos;
    Vector3 endPos;
    bool goLeft = true;
    bool isChasing = false;

    // Use this for initialization
    void Start () {
        if (!rb) {
            rb = GetComponent<Rigidbody>();
        }
        Bury();
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (burried && !canMove)
        {
            if (IsOpen())
            {
                canMove = true;
            }
        }
        else if (burried && canMove)
        {
            DigToOpening();
        }
        else if (!burried && canMove) {
            Move();
        }
	}

    private void Move()
    {
        if (!isChasing) {
            if (goLeft)
            {
                rb.AddForce(Vector3.left * groundSpeed);
            }
            else {
                rb.AddForce(Vector3.right * groundSpeed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GetDirectionOfCollision(collision) == Vector3.left) {
            goLeft = false;
        }
        if (GetDirectionOfCollision(collision) == Vector3.right) {
            goLeft = true;
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

    void DigToOpening() {
        if (transform.position != endPos)
        {
            transform.position += dirOfOpening * digSpeed;
        }
        else {
            Unbury();
        }
    }

    void Unbury() {
        rb.isKinematic = false;
        coll.enabled = true;
        burried = false;
        canMove = true;
    }

    void Bury() {
        rb.isKinematic = true;
        coll.enabled = false;
        burried = true;
        canMove = false;
    }

    bool IsOpen() {
        return IsOpeningAbove() || IsOpeningBelow() || IsOpeningLeft() || IsOpeningRight();
    }

    bool IsOpeningAbove() {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.distance > 0.32f || hit.transform == null) {
            UpdatePos(Vector3.up);
            return true;
        }
        return false;
    }
    bool IsOpeningBelow()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.distance > 0.32f || hit.transform == null)
        {
            UpdatePos(Vector3.down);
            return true;
        }
        return false;
    }
    bool IsOpeningRight()
    {
        Ray ray = new Ray(transform.position, Vector3.right);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.distance > 0.32f || hit.transform == null)
        {
            UpdatePos(Vector3.right);
            return true;
        }
        return false;
    }
    bool IsOpeningLeft()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.distance > 0.32f || hit.transform == null)
        {
            UpdatePos(Vector3.left);
            return true;
        }
        return false;
    }
    void UpdatePos(Vector3 dir) {
        startPos = transform.position;
        dirOfOpening = dir;
        endPos = startPos + (dir * 0.33f);
    }
}
