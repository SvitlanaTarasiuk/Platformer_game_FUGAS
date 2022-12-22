using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    bool moveingBack;
    Vector2 currentPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player"&&moveingBack==false)
        {
            Invoke("FallPlatform", 1f);         
        }
    }
    void FallPlatform()
    {
        rb.isKinematic = false;
        Invoke("BackPlatform", 5f);
    }
    void Update()
    {
        MovePlatform();   
    }
    void MovePlatform()
    {
        if (moveingBack == true)
        { 
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, 20f - Time.deltaTime); 
        }
        if (transform.position.y == currentPosition.y)
        {
            moveingBack = false;
        }
    }
    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        moveingBack = true;
    }
}
