using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS1Player : MonoBehaviour
{

    private Rigidbody2D rb;
    [Header("�������")]
    public Animator anim;
    public Collider2D coll;
    public Collider2D disColl;

    [Header("����")]
    public float speed;

    [Header("����")]
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
        

        Invoke("Dialog", 2);//�����Ի�
        Invoke("baomao", 2.8f);

        Invoke("ThankDialog", 3);
        //Invoke("ThankImage", 4);//������л����
        Invoke("Rub", 5);//
        Invoke("ShutImage", 6);
        Invoke("StartBlack", 8);//

        Invoke("StartDiary2", 10);//�����ռ�

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
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
        //����

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
