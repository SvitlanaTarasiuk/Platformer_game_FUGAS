using UnityEngine;

public class SpikeWalk: MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private int lifeWalk = 2;
    private SpriteRenderer sprRend;
    private float speed = 3f;
    private bool moveingRigth = true;
    
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (moveingRigth && transform.position.x > point2.position.x)
        {
            moveingRigth = false;
            sprRend.flipX = true;
        }
        else if (!moveingRigth && transform.position.x < point1.position.x)
        {
            moveingRigth = true;
            sprRend.flipX = false;
        }
        if (moveingRigth)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);           
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);            
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Player")
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

