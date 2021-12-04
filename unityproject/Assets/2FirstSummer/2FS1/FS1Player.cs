using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS1Player : MonoBehaviour
{

    private Rigidbody2D rb;
    [Header("基本组件")]
    public Animator anim;
    public Collider2D coll;
    public Collider2D disColl;

    [Header("参数")]
    public float speed;

    [Header("触发")]
    public GameObject startImage;
    public GameObject dialog;
    public GameObject thankImage;
    public GameObject black;
    public GameObject diary2;
    public GameObject thankDialog;
    public GameObject cat;

    public AudioSource seaAudio;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        Invoke("Dialog", 2);//启动对话
        Invoke("baomao", 2.8f);

        Invoke("ThankDialog", 3);
        //Invoke("ThankImage", 4);//启动感谢画面
        Invoke("Rub", 5);//
        Invoke("ShutImage", 6);
        Invoke("StartBlack", 8);//

        Invoke("StartDiary2", 10);//启动日记

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
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



    void Dialog()
    {
        dialog.SetActive(true);
    }
    void baomao()
    {
        cat.SetActive(false);
    }    

    void ThankImage()
    {
        dialog.SetActive(false);
        startImage.SetActive(false);

        thankImage.SetActive(true);
    }
    void ThankDialog()
    {
        dialog.SetActive(false);
        thankDialog.SetActive(true);
    }
    void Rub()
    {
        thankImage.SetActive(false);
        thankDialog.SetActive(false);
        //动画

    }

    void ShutImage()
    {
        startImage.SetActive(false);
    }

    void StartBlack()
    {
        
        black.SetActive(true);
        seaAudio.Stop();
    }
    void StartDiary2()
    {

        diary2.SetActive(true);
        
    }
}
