using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PriestController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform viewPlatform;
    //public GameObject buttonW;
    public float speed;

    public GameObject memory;
    public GameObject keyPrompt;
    public GameObject diary5;
    public GameObject goKeyPrompt;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject player;
    public Animator anim;
    public AudioSource audio_wa;
    private void Start()
    {
        anim.SetBool("prMove", true);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        //���ռ�
        if(keyPrompt.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            keyPrompt.SetActive(false);
            diary5.SetActive(true);
        }
        if(goKeyPrompt.activeSelf && Input.GetKeyDown(KeyCode.W))
        {
            dialog1.SetActive(true);
            goKeyPrompt.SetActive(false);
            Invoke("StartDialog2", 3);
            Invoke("LoadViewPlatform", 6);

        }
        if(goKeyPrompt.activeSelf && Input.GetKeyDown(KeyCode.D))
        {
            dialog1.SetActive(true);
            goKeyPrompt.SetActive(false);
            Invoke("StartDialog2", 3);
            Invoke("LoadCemetery", 6);
        }

    }




    //��������ͼ
    void StartMemory()
    {
        memory.SetActive(true);
        anim.SetBool("memory", true);
    }
    void mermoryOver()
    {
        anim.SetBool("memoryover", true);
   
    }

    //����Tab��ʾ
    void StartPrompt()
    {
        //memory.SetActive(false);
        keyPrompt.SetActive(true);
    }

    void StartGoKeyPrompt()
    {
        goKeyPrompt.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ViewPlatform")
        {
            anim.SetBool("prMove", false);
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //Ů����ͷ�����۹۾�̨�ķ����ֵ�ͷ������ϥ���ϵĺ���
            Invoke("StartMemory", 3);//�ӳ���������
           
            Invoke("StartPrompt", 6);//�ӳ�����������ʾTab



        }
        if(collision.tag=="Hole")
        {
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            player.SetActive(true);
            anim.SetBool("SSPriest", true);
            audio_wa.Play();
            Invoke("LoadEnd", 6);
        }
    }


    void StartDialog2()
    {

        dialog1.SetActive(false);
        dialog2.SetActive(true);
    }

    void LoadViewPlatform()
    {
        SceneManager.LoadScene("51SSViewPlatform");
    }
    void LoadCemetery()
    {
        speed = 2;
        dialog2.SetActive(false);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void LoadEnd()
    {
        SceneManager.LoadScene("6End");
    }

    
}
