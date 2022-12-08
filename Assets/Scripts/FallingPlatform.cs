using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Invoke("FallPlatform", 1f);
            Destroy(gameObject, 2f);
        }
    }
    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
