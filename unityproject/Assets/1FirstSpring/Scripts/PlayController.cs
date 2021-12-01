using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public Animator anim;
    public Collider2D coll;
    public Collider2D disColl;
    public float speed;
    [Header("跳跃参数")]
    public Transform groundCheck;
    public LayerMask ground;
    
    public float jumpForce;
    public bool isGround;
    public bool jumpPressed;

    [Header("靠近猫触发")]
    public GameObject approachButtonF;
    public GameObject cat_ButtonF;
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;

    [Header("长按触发")]
    public float duration=2;
    public float buttonTime;
    public bool isLong=false;
    public GameObject longButtonF;
    [Header("结束")]
    
    public SpriteRenderer back;
    public GameObject black;


    // Start is called before the first frame update
    void Start()
    {
        
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

        if(approachButtonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            approachButtonF.SetActive(false);
            //向前走动画
        }
        if(cat_ButtonF.activeSelf&&Input.GetKeyDown(KeyCode.F))
        {
            cat_ButtonF.SetActive(false);
            //撸猫动画
            Invoke("StartLongButton", 3);//启动抱猫按钮F

        }
        if(longButtonF.activeSelf && isLong)//Input.GetKeyDown(KeyCode.F)
        {
            longButtonF.SetActive(false);
            //抱猫动画
            back.color = new Color(1, 1, 1, 1);
            Camera.main.orthographicSize = 10;
            Invoke("StartBlack", 3);
            Invoke("LoadNext", 4);
        }

        //长按判定
        if (longButtonF.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                //if (Input.GetKey(KeyCode.F))
                //{
                    buttonTime = Time.time + duration;

                //}
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                if (buttonTime < Time.time)
                {
                    isLong = true;

                }
            }
        }

    }

    void StartBlack()
    {
        black.SetActive(true);
    }
    void LoadNext()
    {
        SceneManager.LoadScene("2FirstSummer");
    }
    void StartLongButton()
    {
        
        longButtonF.SetActive(true);
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

    //接近猫
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="CatCheck")
        {
            approachButtonF.SetActive(true);

        }
        if (collision.tag == "Cat")
        {
            cat_ButtonF.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="CatCheck")
        {
            approachButtonF.SetActive(false);
        }

        if (collision.tag == "Cat")
        {
            cat_ButtonF.SetActive(false);
        }
    }

    









}
