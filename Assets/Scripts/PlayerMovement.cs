using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float groundSpeed = 8f;
    [SerializeField]
    float airSpeed = 2f;
    [SerializeField]
    float jumpForce = 3f;
    [SerializeField]
    bool canJump = true;
    [SerializeField]
    int health = 3;
    public bool canMove = true;

    bool isStuck = false;
    bool canStick = false;
    float stuckTime = 5;
    float stickInvTime = 5;
    float t = 0;
    float it = 0;

    // Use this for initialization
    void Awake () {
        Restart();
	}

    void Update()
    {
        if (!isStuck) {
            if (canMove)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (canJump)
                    {
                        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * groundSpeed);
                    }
                    else
                    {
                        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * airSpeed);
                    }
                }

                if (canJump)
                {
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                        canJump = false;
                    }
                }
            }
        }
        else
        {
            if (t < stuckTime)
            {
                t += Time.deltaTime / stuckTime;
            }
            else
            {
                isStuck = false;
                canStick = false;
                t = 0;
            }
        }
        if (!canStick)
        {
            if (it < stickInvTime)
            {
                it += Time.deltaTime / stickInvTime;
            }
            else
            {
                canStick = true;
                it = 0;
            }
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

    public void Damage() {
        health--;
        if (health == 0) {
            Die();
        }
    }

    void Die() {
        Time.timeScale = 0;
        canMove = false;
    }

    public void Restart()
    {
        if (!rb)
        {
            rb = GetComponent<Rigidbody>();
        }
        groundSpeed = 8;
        jumpForce = 3;
        airSpeed = 2;
        canJump = true;
        health = 3;
        canMove = true;
        isStuck = false;
        canStick = false;
        stuckTime = 5;
        stickInvTime = 5;
        t = 0;
        it = 0;
    }
    public void Stuck() {
        if (canStick)
        {
            isStuck = true;
        }
    }
}
