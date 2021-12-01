using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW2Player : MonoBehaviour
{
    
    [Header("基本组件")]
    public Rigidbody2D rb;
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
    public GameObject diary;
    public GameObject buttonF;
    public GameObject buttonF1;

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
        /*if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            diary.SetActive(true);
            Time.timeScale = 0;
        }
        if (!diary.activeSelf)
        {
            Time.timeScale = 1;
        }*/


        /*if(buttonF1.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            buttonF1.SetActive(true);
            //开门
        }*/

        if (buttonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            buttonF.SetActive(false);
            //生火
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag=="Door")
        {
            buttonF1.SetActive(true);
        }


        if (collision.tag == "FirePlace")
        {
            buttonF.SetActive(true);

        }
        
    }






}
