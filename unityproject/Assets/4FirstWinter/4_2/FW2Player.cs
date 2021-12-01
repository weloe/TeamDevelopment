using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW2Player : MonoBehaviour
{
    
    [Header("�������")]
    public Rigidbody2D rb;
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
        //��Ծ���
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
            //����
        }*/

        if (buttonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            buttonF.SetActive(false);
            //����
        }
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
