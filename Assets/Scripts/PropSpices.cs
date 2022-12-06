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
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Bluster")
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


