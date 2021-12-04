using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW2DoorController : MonoBehaviour
{

    public GameObject doorButtonF;
    public Collider2D disColl;
    public Collider2D disColl1;
    public float time;
    public float duration;
    public float count = 2;
    public bool isButton = false;
    public AudioSource door;
    public AudioSource house;


    // Start is called before the first frame update
    void Start()
    {
        disColl.enabled = false;
        //
        /*if()
        {
            //开门动画
            
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        



        if (doorButtonF.activeSelf )
        {
            if(Input.GetKeyDown(KeyCode.F) && count==2)
            {
                time = Time.time+duration;
                count--;
            }
            if(Input.GetKeyDown(KeyCode.F) && count == 1)
            {
                if(Time.time>time)
                {
                    disColl.enabled = true;
                    disColl1.enabled = false;
                    doorButtonF.SetActive(false);
                    Camera.main.orthographicSize = 4;
                    door.Play();
                    house.Play();
                    //关门动画
                }
                
                
                
            }
            
            
        }
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            doorButtonF.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorButtonF.SetActive(false);
        }
    }




}
