using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummerPlayer : MonoBehaviour
{
    
    private Rigidbody2D rb;
    [Header("基本组件")]
    public Animator anim;
    public Collider2D coll;
    public Collider2D disColl;

    [Header("跳跃参数")]
    public Transform groundCheck;
    public LayerMask ground;
    public float speed;
    public float jumpForce;
    public bool isGround;
    public bool jumpPressed;

    [Header("触发")]
    public GameObject buttonW;
    public GameObject buttonF;
    public Transform sea;
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;
    public GameObject black;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {


        Jump();
        //跳跃检测
        if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpPressed = true;
        }
        GoSea();
        if (transform.position.y >= 2)
        {
            speed = 0;
            rb.velocity = new Vector2(rb.velocity.x, speed);

            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);//

        
        Movement();
        
    }

    //人物移动
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


        //面向的方向
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
            anim.SetBool("Move2", true);
        }
        if (facedirection == 0)
        {
            anim.SetBool("Move2", false);
        }


    }

    //跳跃
    void Jump()
    {
        if (jumpPressed && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpPressed = false;

            //anim.SetBool("jumping", true);

        }
    }



    void GoSea()
    {
        

        if(buttonW.activeSelf && Input.GetKeyDown(KeyCode.W))
        {
            buttonW.SetActive(false);
            anim.SetBool("seamove", true);

            rb.velocity = new Vector2(rb.velocity.x, 4/3);
            //向海走的动画
            
            Invoke("Tumble", 3);
            speed = 0;
            
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            //站立动画
            buttonF.SetActive(false);
            Invoke("Tumble", 1);
            black.SetActive(true);
            

            //
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SeaCheck")
        {
            buttonW.SetActive(true);

        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SeaCheck")
        {
            buttonW.SetActive(false);
        }

    }
    //摔倒
    void Tumble()
    {
        //播放摔倒动画
        buttonF.SetActive(true);//出现buttonF

        Invoke("LoadNext", 3);
    }

    void LoadNext()
    {
        SceneManager.LoadScene("2FS1");
    }
    
}
