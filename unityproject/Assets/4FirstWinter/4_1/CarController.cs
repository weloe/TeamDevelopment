using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    
    public float speed;
    public GameObject buttonF;
    
    void Start()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }


    void Update()
    {
        /*if (transform.position.x >= player.position.x)
        {
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            buttonF.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(buttonF);
                
                Invoke("CarMove", 3);
            }
        }*/
        //角色上车
        if (buttonF.activeSelf && Input.GetKeyDown(KeyCode.F) )
        {
            
            buttonF.SetActive(false);
            speed = 2;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            player.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //停车
        if(collision.tag=="Player" )
        {
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            buttonF.SetActive(true);
        }
        

    }



}
