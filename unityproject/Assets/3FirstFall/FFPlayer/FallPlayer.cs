using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlayer : MonoBehaviour
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
    public Transform cat_LeftCheck;
    public Transform cat_RightCheck;
    public Transform cat;
    [Header("�ռ�")]
    public GameObject diary;
    bool sum = false;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //Invoke("revealDialog", 2f);//�ӳ���ʾ�ռ�����
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

        SwitchDialog();

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
            anim.SetBool("Move3", true);
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if (facedirection == 0)
        {
            anim.SetBool("Move3", false);
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
    //�ռ���ʾ
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
