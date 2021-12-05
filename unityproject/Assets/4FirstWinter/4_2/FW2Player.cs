using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject fire;
    public Collider2D fireColl;
    public GameObject back1;
    public GameObject back2;
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
            fire.SetActive(true);
            back1.SetActive(false);
            back2.SetActive(true);
            //����
            fireColl.enabled = false;

            Invoke("LoadNext", 1);
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
            anim.SetBool("Move42", true);
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if (facedirection == 0)
        {
            anim.SetBool("Move42", false);
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


        /*if (collision.tag == "FirePlace")
        {
            buttonF.SetActive(true);

        }*/
        
    }

    void LoadNext()
    {
        black.SetActive(true);
    }
    




}
