using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHp;
    public Animator animator;
    private SpriteRenderer sprRend;
    private Object explosion;
    //public Transform attackPoint;
   // public float attackRange = 0.5f;
    private int live_hp = 10;
    private int hp_Current;
    private float speed = 3f;
    private bool moveingRigth = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();
        explosion = Resources.Load("Explosion");
        hp_Current = live_hp;
    }
    void Update()
    {
        if (transform.position.x > 12f)
        {
            moveingRigth = false;
        }
        else if (transform.position.x < -1f)
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
        //Physics.OverlapSphere(attackPoint.position,attackRange);
    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //        return;
    //    Gizmos.DrawSphere(attackPoint.position,attackRange);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Bluster")
        {
            hp_Current--;
            imageHp.fillAmount = (float)hp_Current / live_hp;
            sprRend.color = colorDamage;

            if (hp_Current <= 0)
            {
                //Destroy(gameObject);
                GameObject explosionRef = (GameObject)Instantiate(explosion);
                explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                animator.SetBool("isDead", true);
                Destroy(this);
                Die();
               
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
    void Die()
    {
       
        Destroy(GetComponent<Rigidbody2D>());   
        Destroy(GetComponent<Collider2D>());
        this.enabled = true;

    }
}
