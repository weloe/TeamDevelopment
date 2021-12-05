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
        //打开日记
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




    //启动回忆图
    void StartMemory()
    {
        memory.SetActive(true);
        anim.SetBool("memory", true);
    }
    void mermoryOver()
    {
        anim.SetBool("memoryover", true);
   
    }

    //启动Tab提示
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
            //女孩侧头看了眼观景台的方向，又低头看了眼膝盖上的盒子
            Invoke("StartMemory", 3);//延迟启动回忆
           
            Invoke("StartPrompt", 6);//延迟启动按键提示Tab



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
