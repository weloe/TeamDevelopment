using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlayer : MonoBehaviour
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
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;
    [Header("日记")]
    public GameObject diary;
    bool sum = false;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //Invoke("revealDialog", 2f);//延迟显示日记内容
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

        SwitchDialog();

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
            anim.SetBool("Move3", true);
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if (facedirection == 0)
        {
            anim.SetBool("Move3", false);
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
    //日记显示
    void revealDialog()
    {
        diary.SetActive(true);
        sum=true;
    }
    void SwitchDialog()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && sum == true)
        {
            sum = false;
            diary.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Tab) && sum == false)
        {
            sum = true;
            diary.SetActive(true);

        }
    }
}
