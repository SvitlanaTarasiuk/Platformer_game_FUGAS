using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private GameUI gameUI;
    //[SerializeField] private Rigidbody2D maceWeapon;
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
    public int weapon = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;


    /*public int Key
    {
        get => key;
        set => key = value;
    }*/
    

    void Awake()
    {
        print("AwakeHero");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //sprite = GetComponentInChildren<SpriteRenderer>();
        //anim = GetComponentInChildren<Animator>();
        //SceneManager.sceneLoaded += LevelLoaded;//Sing            //підписка на подію завантаження сцени    
    }

    void Start()
    {
        print("StartHero");

        gold = GlobalControl.Instantiate.gold;
        life = GlobalControl.Instantiate.life;
        food = GlobalControl.Instantiate.food;
        weapon = GlobalControl.Instantiate.weapon;
        SetValueInUI();
        //gameUI = GlobalControl.Instantiate.gameUI;
    }

    public void SavePlayer()
    {
        GlobalControl.Instantiate.gold = gold;
        GlobalControl.Instantiate.life = life;
        GlobalControl.Instantiate.food = food;
        GlobalControl.Instantiate.weapon = weapon;
        //GlobalControl.Instantiate.gameUI = gameUI;
    }

     void SetValueInUI()//Sing
    {
        print("SetValueInUI");
        gameUI.SetCountGoldUI(gold);
        gameUI.SetCountFoodUI(food);
        gameUI.SetCountWeaponUI(weapon);
        gameUI.SetCountLifeUI(life);

    }
   /* private void LevelLoaded(Scene scene, LoadSceneMode mode)
    {
        print("LevelLoaded");
        SetValueInUI();
        //ConnectUI();
    }*/

    /*void ConnectUI()
    {
        try
        {
            print($"{SingletoneHero._singletoneHero.transform}, {transform} try");

            if (SingletoneHero._singletoneHero.transform == transform)
            {
                print("ConnectUI");
                gameUI = FindObjectOfType<GameUI>();
                SetValueInUI();
            }
        }
        catch (MissingReferenceException e)
        {
            _ = e;
           print($"{SingletoneHero._singletoneHero.transform}, {transform} - {e}");
        }
    }
    public void NewStartParametr()
    {
        print("NewStartParametr");
        coins = 0;
        diamond = 0;
        silver = 0;
        life = 5;
        key = 0;
        SetValueInUI();
    }*/
    private void FixedUpdate()
    {
        CheckGround();
    }
    void Update()
    {
        // if (Time.timeScale >= 1)
        if (isController)
        {
            Jump();
            Attack();
            Run();
        }
    }   
    public void Run()
    {
        if (!isMobileController)
        {
            move = Input.GetAxis("Horizontal");
        }
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);

        //Vector3 dir = transform.right * move;
        //ransform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        anim.SetFloat("SpeedX", Mathf.Abs(move));
        Flip(move);
    }
    public void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim.SetFloat("SpeedY",rb.velocity.y);
        }
    }
    public void JumpMobile()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim.SetFloat("SpeedY", Mathf.Abs(rb.velocity.y));
            //anim.SetBool("isGround", isGrounded);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircleAll(groundPoint.position, 0.5f).Length > 1;
        anim.SetBool("isGround",isGrounded);
        //Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + Vector3.down, 2f);
        //isGrounded = collider.Length > 1;
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
            gold += 100;
            SavePlayer();
            gameUI.SetCountGoldUI(gold);
            //gameUI.SetCountCoinUI();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Food")
        {
            food += 1;
            SavePlayer();
            gameUI.SetCountFoodUI(food);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Heart")
        {
            life += 1;
            SavePlayer();
            gameUI.AddHeart();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Weapon")
        {
            weapon += 5;
            SavePlayer();
            gameUI.SetCountWeaponUI(weapon);
            Destroy(collision.gameObject);
        }
        /*if (collision.tag == "Walk")
        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }*/
       if (collision.tag == "Spices,Fire")

        {
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "RestartPoint")
        {
            Damage();
        }
        /*if (collision.tag == "Key")
        {
            key += 1;
            Destroy(collision.gameObject);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Platform")
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
        if (isAttack || Input.GetKeyDown(KeyCode.Return) && weapon > 0)
        //if (Input.GetKeyDown(KeyCode.Return) && silver > 0)
        {
            weapon--;
            SavePlayer();
            gameUI.SetCountWeaponUI(weapon);
           // anim......
            //Rigidbody2D tempWeapon = Instantiate(maceWeapon, transform.position, Quaternion.identity);
            //tempWeapon.AddForce(new Vector2(isRigth ? 300 : -300, 0));
           /* if (!isRigth)
            {
                SpriteRenderer srSilver = tempWeapon.GetComponent<SpriteRenderer>();
                srSilver.flipX = true;
                srSilver.flipY = true;
            }*/
        }
    }
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
        Restart();

        if (life == 0)
        {
            print("Life=0_DamageActivelGameOver");
            Time.timeScale = 0;
            gameUI.GameOver();

        }

    }

}
