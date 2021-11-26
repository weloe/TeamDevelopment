using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
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

    [Header("����è����")]
    public GameObject approachButtonF;
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;
    

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



    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);//

        IsApproach();
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
    void IsApproach()
    {
        
        if (transform.position.x >= cat_LeftCheck.transform.position.x && transform.position.x <= cat_RightCheck.transform.position.x)
        {

            approachButtonF.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                //��ǰ�߶���
            }
            
        }
        else
        {

            approachButtonF.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
            {
                //��ǰ�߶���
            }

        }

    }






}
