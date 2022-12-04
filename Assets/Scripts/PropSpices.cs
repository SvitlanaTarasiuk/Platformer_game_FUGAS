using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpices : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    private int lifeProp = 2;
    private SpriteRenderer sprRend;

    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
    }
    private void OnTrigerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            lifeProp--;
            sprRend.color = colorDamage;

            if (lifeProp <= 0)
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


