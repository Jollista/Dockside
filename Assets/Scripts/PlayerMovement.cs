using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Components")]
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;

    [Header ("Movement Details")]
    public bool canMove = true;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if can't move, then set velocity to zero and return
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        //else
        //Get value of horiz/vert axes
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
           
        //update velocity toward given player input at speed
        rb.velocity = new Vector2(dirX * speed, dirY * speed);
    }
}
