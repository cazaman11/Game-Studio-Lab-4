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
    float airSpeed = 1f;
    [SerializeField]
    float jumpForce = 3f;
    [SerializeField]
    float digSpeed = 0.001f;
    [SerializeField]
    bool canJump = false;
    bool canMove = false;
    bool burried = true;
    Vector3 dirOfOpening = Vector3.zero;
    Vector3 startPos;
    Vector3 endPos;

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
        else if (burried && canMove) {
            DigToOpening();
        }
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
        canJump = true;
    }

    void Bury() {
        rb.isKinematic = true;
        coll.enabled = false;
        burried = true;
        canMove = false;
        canJump = false;
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
        endPos = startPos + (dir * 0.32f);
    }
}
