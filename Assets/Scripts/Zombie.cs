using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHp;
    private int live_hp = 10;
    private int hp_Current;
    private SpriteRenderer sprRend;
    private float speed = 3f;
    private bool moveingRigth = true;
    private Object explosion;
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        explosion = Resources.Load("Explosion");
        hp_Current = live_hp;
    }
    void Update()
    {
        if (transform.position.x > 7f)
        {
            moveingRigth = false;
        }
        else if (transform.position.x < -3f)
        {
            moveingRigth = true;
        }
        if (moveingRigth)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            sprRend.flipX = false;
        }       
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            sprRend.flipX = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Silver")
        {
            hp_Current--;
            imageHp.fillAmount = (float)hp_Current / live_hp;
            sprRend.color = colorDamage;

            if (hp_Current <= 0)
            {
                Destroy(gameObject);
                GameObject explosionRef = (GameObject)Instantiate(explosion);
                explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
