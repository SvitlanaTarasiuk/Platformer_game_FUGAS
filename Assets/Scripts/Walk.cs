using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk: MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private int lifeWalk = 2;
    private SpriteRenderer sprRend;
    private Rigidbody2D rb;
    private float speed = 3f;
    private bool moveingRigth = true;
    
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (moveingRigth)
        {
            if (transform.position.x > point2.position.x)
            {
                moveingRigth = false;
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                sprRend.flipX = true;

            }
        }
        else
        {
            if (transform.position.x < point1.position.x)
            {
                moveingRigth = true;
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                sprRend.flipX = false;
            }
        }

    }
    private void OnTrigerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            lifeWalk--;
            sprRend.color = colorDamage;

            if (lifeWalk <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Invoke("ResetMaterial", 0.5f);
            }
        }

    }
    void ResetMaterial()
    {
        sprRend.color = Color.white;
    }
}

