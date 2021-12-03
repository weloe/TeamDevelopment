using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    public GameObject flash;
    public SpriteRenderer color1;
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
            flash.SetActive(true);
            color1.color = new Color(1, 1, 1, 1);
        }
    }
}
