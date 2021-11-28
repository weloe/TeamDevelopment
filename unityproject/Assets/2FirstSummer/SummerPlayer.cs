using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerPlayer : MonoBehaviour
{
    
    private Rigidbody2D rb;
    [Header("�������")]
    public Animator anim;
    public Collider2D coll;
    public Collider2D disColl;

    [Header("��Ծ����")]
    public Transform groundCheck;
    public LayerMask ground;
    public float speed;
    public float jumpForce;
    public bool isGround;
    public bool jumpPressed;

    [Header("����")]
    public GameObject buttonW;
    public GameObject buttonF;
    public Transform sea;
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        GoSea();


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



    void GoSea()
    {
        

        if(buttonW.activeSelf && Input.GetKeyDown(KeyCode.W))
        {
            //���ߵĶ���
            Invoke("Tumble", 3);
            buttonW.SetActive(false);
        }

        if (buttonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            //վ������
            Invoke("Tumble", 1);
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
    //ˤ��
    void Tumble()
    {
        //����ˤ������
        buttonF.SetActive(true);//����buttonF
        
    }

}
