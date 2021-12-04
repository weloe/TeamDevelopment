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
    [Header("���رʼǱ�")]
    public GameObject diary_Text;
    public GameObject keyPrompt;
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

    [Header("��������")]
    public float duration=2;
    public float buttonTime;
    public bool isLong=false;
    public GameObject longButtonF;
    [Header("����")]
    
    public SpriteRenderer back;
    public GameObject black;
    public float facedirection;

    [Header("��Ƶ")]
    public AudioSource baomao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���رʼǱ�
        if ( Input.GetKeyDown(KeyCode.Tab))
        {
            
            diary_Text.SetActive(true);
            
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&& diary_Text.activeSelf)
        {
            
            diary_Text.SetActive(false);
            
            Time.timeScale = 1;
        }


        Jump();
        //��Ծ���
        if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpPressed = true;
        }

        /*if(approachButtonF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            approachButtonF.SetActive(false);
            //��ǰ�߶���
        }
        if(cat_ButtonF.activeSelf&&Input.GetKeyDown(KeyCode.F))
        {
            cat_ButtonF.SetActive(false);
            //ߣè����
            Invoke("StartLongButton", 3);//������è��ťF

        }*/
        if(longButtonF.activeSelf && isLong)//Input.GetKeyDown(KeyCode.F)
        {
            

            longButtonF.SetActive(false);
            //��è����
            anim.SetBool("baomao", true);
            baomao.Play();
            back.color = new Color(1, 1, 1, 1);
            //Camera.main.orthographicSize = 10;
           
            //Invoke("StartBlack", 3);
            //Invoke("LoadNext", 4);
        }
        if(anim.GetBool("baomao"))
        {
            facedirection = Input.GetAxisRaw("Horizontal");
            anim.SetFloat("baomaoMove", Mathf.Abs(facedirection));
        }

        //�����ж�
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

    //�����ƶ�
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


        //����ķ���
        if (facedirection != 0)
        {
            anim.SetBool("Move", true);
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if(facedirection == 0)
        {
            anim.SetBool("Move", false);
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
        /*if(collision.tag=="CatCheck")
        {
            approachButtonF.SetActive(true);

        }
        if (collision.tag == "Cat")
        {
            cat_ButtonF.SetActive(true);
        }*/

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
