using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour {

    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Collider coll;
    [SerializeField]
    float groundSpeed = 8f;
    [SerializeField]
    float upSpeed = 3.5f;
    [SerializeField]
    float airSpeed = 2f;
    bool canJump = false;
    [SerializeField]
    float currSpeed = 0;
    [SerializeField]
    float digSpeed = 0.001f;
    [SerializeField]
    float tileSize = 0.32f;
    bool canMove = false;
    bool burried = true;
    Vector3 dirOfOpening = Vector3.zero;
    Vector3 startPos;
    Vector3 endPos;
    bool goLeft = true;
    bool isChasing = false;
    GameObject chaseTarget;
    [SerializeField]
    int health = 3;

    // Use this for initialization
    void Start () {
        Restart();
    }

    public void Restart() {
        if (!rb)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (!coll)
        {
            coll = GetComponent<Collider>();
        }
        startPos = transform.position;
        groundSpeed = 8f;
        upSpeed = 3.5f;
        airSpeed = 2f;
        canJump = false;
        currSpeed = 0;
        digSpeed = 0.001f;
        tileSize = 0.32f;
        canMove = false;
        burried = true;
        dirOfOpening = Vector3.zero;
        endPos = startPos;
        goLeft = true;
        isChasing = false;
        chaseTarget = null;
        health = 3;
        Bury();
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
        else if (!burried && canMove)
        {
            Move();
        }
        
	}

    private void Move()
    {
        if (!isChasing)
        {
            if (goLeft)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
        else {
            Vector3 dir = GetDirectionOfCollision(chaseTarget);
            if (dir.x > 0)
            {
                if (IsOpeningRight())
                {
                    MoveRight();
                }
                else
                {
                    if (IsOpeningAbove())
                    {
                        MoveUp();
                    }
                    else
                    {
                        MoveLeft();
                    }
                }
            }
            else if (dir.x < 0)
            {
                if (IsOpeningLeft())
                {
                    MoveLeft();
                }
                else
                {
                    if (IsOpeningAbove())
                    {
                        MoveUp();
                    }
                    else
                    {
                        MoveRight();
                    }
                }
            }
            else {
                if (dir.y > 0)
                {
                    if (IsOpeningAbove())
                    {
                        MoveUp();
                    }
                    else
                    {
                        if (dir.x < 0)
                        {
                            if (IsOpeningLeft())
                            {
                                MoveLeft();
                            }
                            
                        }
                        else if (dir.x > 0)
                        {
                            if (IsOpeningRight()) {
                                MoveRight();
                            } 
                        }
                    }
                }
                else {
                    if (dir.x < 0)
                    {
                        if (IsOpeningLeft())
                        {
                            MoveLeft();
                        }

                    }
                    else if (dir.x > 0)
                    {
                        if (IsOpeningRight())
                        {
                            MoveRight();
                        }
                    }
                }
            }
        }
    }

    void MoveLeft() {
        rb.AddForce(Vector3.left * currSpeed);
    }

    void MoveRight() {
        rb.AddForce(Vector3.right * currSpeed);
    }

    void MoveUp() {
        if (canJump)
        {
            rb.AddForce(Vector3.up * upSpeed, ForceMode.Impulse);
            canJump = false;
            currSpeed = airSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isChasing)
        {
            if (GetDirectionOfCollision(collision.gameObject) == Vector3.left)
            {
                goLeft = false;
            }
            if (GetDirectionOfCollision(collision.gameObject) == Vector3.right)
            {
                goLeft = true;
            }
        }
        if (GetDirectionOfCollision(collision.gameObject).y < 0 && !canJump) {
            canJump = true;
            currSpeed = groundSpeed;
        }
        if (collision.gameObject.tag == "Player") {
            Attack(collision.gameObject);
        }
    }

    void Attack(GameObject player) {
        if (player.GetComponent<PlayerMovement>()) {
            player.GetComponent<PlayerMovement>().Damage();
        }
        Vector3 dir = GetDirectionOfCollision(player);
        rb.AddForce(dir * 2, ForceMode.Impulse);
    }

    public void Damage() {
        health--;
        if (health == 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!burried && canMove && !isChasing) {
            if (other.tag == "Player") {
                isChasing = true;
                chaseTarget = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            isChasing = false;
            chaseTarget = null;
        }
    }

    private Vector3 GetDirectionOfCollision(GameObject other)
    {
        Vector3 direction = (other.transform.position - transform.position);
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
            return -normal;
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
        canJump = true;
        currSpeed = groundSpeed;
    }

    void Bury() {
        rb.isKinematic = true;
        coll.enabled = false;
        burried = true;
        canMove = false;
        canJump = false;
        currSpeed = 0;
    }

    bool IsOpen() {
        return IsOpeningAbove() || IsOpeningBelow() || IsOpeningLeft() || IsOpeningRight();
    }

    bool IsOpeningAbove() {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.distance > tileSize || hit.transform == null) {
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
        if (hit.distance > tileSize || hit.transform == null)
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
        if (hit.distance > tileSize || hit.transform == null)
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
        if (hit.distance > tileSize || hit.transform == null)
        {
            UpdatePos(Vector3.left);
            return true;
        }
        return false;
    }
    void UpdatePos(Vector3 dir) {
        startPos = transform.position;
        dirOfOpening = dir;
        endPos = startPos + (dir * (tileSize+0.01f));
    }
}
