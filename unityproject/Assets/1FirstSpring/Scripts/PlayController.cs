using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public Animator anim;
    public Collider2D coll;
    public Collider2D disColl;
    public float speed;
    [Header("��Ծ����")]
    public Transform groundCheck;
    public LayerMask ground;
    
    public float jumpForce;
    public bool isGround;
    public bool jumpPressed;

    [Header("����è����")]
    public GameObject approachButtonF;
    public GameObject cat_ButtonF;
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;
    public GameObject longButtonF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Jump();
        //��Ծ���
        if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpPressed = true;
        }

        if(approachButtonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            approachButtonF.SetActive(false);
            //��ǰ�߶���
        }
        if(cat_ButtonF.activeSelf&&Input.GetKeyDown(KeyCode.F))
        {
            cat_ButtonF.SetActive(false);
            //ߣè����
            Invoke("StartLongButton", 3);//������è��ťF

        }
        if(longButtonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            longButtonF.SetActive(false);
            //��è����
        }

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

    //�����ƶ�
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


        //����ķ���
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }


    }

    //��Ծ
    void Jump()
    {
        if (jumpPressed && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpPressed = false;
            //anim.SetBool("jumping", true);
            
        }
    }

    //�ӽ�è
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
