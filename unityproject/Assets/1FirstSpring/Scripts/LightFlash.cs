using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    public GameObject flash;
    public SpriteRenderer color1;
    public AudioSource audio1;
    public AudioSource audio2;
    public Collider2D coll;
    public float startAlpha;
    public float x;
    public float alphax;
    public bool aaa=false;
    public Animator anim;
    void Start()
    {
        //alphax = startAlpha * x;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(aaa)
        {
            color1.color = new Color(1, 1, 1, alphax);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            flash.SetActive(true);
            audio1.Play();
            audio2.Play();
            color1.color = new Color(1, 1, 1, 1);
            //aaa = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            coll.enabled = false;
            //anim.SetBool("FSPcar",true);
        }
        
    }
}
