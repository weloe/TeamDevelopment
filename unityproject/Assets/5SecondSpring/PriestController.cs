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



    private void Start()
    {
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
    }

    //����Tab��ʾ
    void StartPrompt()
    {
        memory.SetActive(false);
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
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //Ů����ͷ�����۹۾�̨�ķ����ֵ�ͷ������ϥ���ϵĺ���
            Invoke("StartMemory", 3);//�ӳ���������
            Invoke("StartPrompt", 6);//�ӳ�����������ʾTab

        }
    }


    void StartDialog2()
    {
        dialog1.SetActive(false);
        dialog2.SetActive(true);
    }

    void LoadViewPlatform()
    {
        SceneManager.LoadScene("ViewPlatform");
    }
    void LoadCemetery()
    {
        speed = 2;
        dialog2.SetActive(false);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

}