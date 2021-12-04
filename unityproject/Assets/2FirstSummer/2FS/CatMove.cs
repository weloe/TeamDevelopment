using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform sea;
    //public GameObject buttonW;
    public float speed;
    public Animator ani;    

    // Start is called before the first frame update
    void Start()
    {
        //buttonW.SetActive(false);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>=sea.position.x)
        {
            speed = 0;
            
            rb.velocity = new Vector2(speed, rb.velocity.y);
            ani.SetBool("CatMove1", false);
        }
        
    }
}
