using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheck : MonoBehaviour
{
    public AudioSource fall;
    public Collider2D coll;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            fall.Play();
            coll.enabled = false;
        }
        
    }

}
