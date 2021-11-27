using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWCar : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;

    public float speed;
    //public GameObject buttonF;

    void Start()
    {

        
    }


    void Update()
    {
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}
