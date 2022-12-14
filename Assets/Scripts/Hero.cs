using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private Rigidbody2D bluster;
    [SerializeField] private Color colorDamage;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform checkPoint;
    [SerializeField] private bool isMobileController = false;
    private bool isController = true;
    public float move;

    private bool isRigth = true;
    private bool isGrounded = false;
    public int gold = 0;
    public int life = 3;
    public int food = 0;
    public int blusterCount = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip audioClip;

    void Awake()
    {
        print("AwakeHero");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //sprite = GetComponentInChildren<SpriteRenderer>();
        //anim = GetComponentInChildren<Animator>();
        //SceneManager.sceneLoaded += LevelLoaded;//Sing            //підписка на подію завантаження сцени    
    }

    void Start()
    {
        print("StartHero");
        GlobalControl.Instance.SaveScene();
        //GlobalControl.Instance.LoadAllData();

        gold = GlobalControl.Instance.gold;
        life = GlobalControl.Instance.life;
        food = GlobalControl.Instance.food;
        blusterCount = GlobalControl.Instance.blusterCount;
        SetValueInUI();
    }

    public void SavePlayer()
    {
        GlobalControl.Instance.gold = gold;
        GlobalControl.Instance.life = life;
        GlobalControl.Instance.food = food;
        GlobalControl.Instance.blusterCount = blusterCount;
    }

    void SetValueInUI()
    {
        print("SetValueInUI");
        gameUI.SetCountGoldUI(gold);
        gameUI.SetCountFoodUI(food);
        gameUI.SetCountBlusterUI(blusterCount);
        gameUI.SetCountLifeUI(life);

    }
  
    private void FixedUpdate()
    {
        CheckGround();
    }
    void Update()
    {
        if (Time.timeScale >= 1)
        {
            if (isController)
            {
                Jump();
                Attack();
                Run();
            }
        }
    }
    public void Run()
    {
        if (!isMobileController)
        {
            move = Input.GetAxis("Horizontal");
        }
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);

        anim.SetFloat("SpeedX", Mathf.Abs(move));
        Flip(move);
    }
    public void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim.SetFloat("SpeedY", rb.velocity.y);
        }
    }
    public void JumpMobile()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim.SetFloat("SpeedY", Mathf.Abs(rb.velocity.y));
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircleAll(groundPoint.position, 0.5f).Length > 1;
        anim.SetBool("isGround", isGrounded);
    }
    private void Flip(float move)
    {
        if (move < 0 && isRigth)
        {
            isRigth = false;
            sprite.flipX = true;
        }
        if (move > 0 && !isRigth)
        {
            isRigth = true;
            sprite.flipX = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gold")
        {
            gold += 10;
            SavePlayer();
            gameUI.SetCountGoldUI(gold);
            PlayerPrefs.SetInt("Gold", gold);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Food")
        {
            food += 1;
            SavePlayer();
            gameUI.SetCountFoodUI(food);
            PlayerPrefs.SetInt("Food", food);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Heart" && life < 3)
        {
            life += 1;
            SavePlayer();
            gameUI.AddHeart();
            PlayerPrefs.SetInt("Life", life);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "BlusterCount")
        {
            blusterCount += 5;
            SavePlayer();
            gameUI.SetCountBlusterUI(blusterCount);
            PlayerPrefs.SetInt("BlusterCount", blusterCount);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Spices")
        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "Fire")
        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "RestartPoint")
        {
            Damage();
        }
       
    }

    /*public void SaveData()
    {
        SavePlayer();
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Food", food);
        PlayerPrefs.SetInt("Life", life);
        PlayerPrefs.SetInt("BlusterCount", blusterCount);

    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        /*if (collision.transform.tag == "Platform")
        {
            transform.parent = collision.transform;
        }*/
        if (collision.transform.tag == "SpikeWalk")
        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.transform.tag == "Prop")
        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.transform.tag == "SpicesUP")
        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            transform.parent = null;
        }
    }*/

    public void Attack(bool isAttack = false)
    {
        if (isAttack || Input.GetKeyDown(KeyCode.Return) && blusterCount > 0)

        {
            blusterCount--;
            SavePlayer();
            gameUI.SetCountBlusterUI(blusterCount);
            PlayerPrefs.SetInt("BlusterCount", blusterCount);

            Rigidbody2D tempBluster = Instantiate(bluster, transform.position, Quaternion.identity);
            tempBluster.AddForce(new Vector2(isRigth ? 300 : -300, 0));
            //anim.SetBool("isAttack", true);
            anim.SetTrigger("Attack");

            if (!isRigth)
            {
                SpriteRenderer srBluster = tempBluster.GetComponent<SpriteRenderer>();
                srBluster.flipX = true;
                srBluster.flipY = true;
            }
        }
    }
    /*public void AttackToogle()
    {
        anim.SetBool("isAttack", false);
    }*/
    public void AttackMomile()
    {
        Attack(true);
    }

    void ResetMaterial()
    {
        sprite.color = Color.white;
    }
    private void Restart()
    {
        if (transform.position.x < checkPoint.position.x)
        {
            transform.position = startPoint.position;
        }

        else if (transform.position.x > checkPoint.position.x)
        {
            transform.position = checkPoint.position;
        }
    }
    private void Damage()
    {
        print("life-1");
        life -= 1;
        SavePlayer();
        gameUI.RemuveHeart();
        PlayerPrefs.SetInt("Life", life);
        Restart();

        if (life == 0)
        {
            print("Life=0_DamageActivelGameOver");
            Time.timeScale = 0;
            gameUI.GameOver();

        }

    }

}
