using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeteryCheck : MonoBehaviour
{
    public AudioSource audio1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Priest") ;
        {
            audio1.Play();
        }
    }
}
