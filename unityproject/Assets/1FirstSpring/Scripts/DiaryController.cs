using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    public GameObject diary_Button;
    public GameObject diary_Text;
    public GameObject keyPrompt;
    public Collider2D coll;
    public GameObject black;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            
            //diary_Button.SetActive(true);
            //keyPrompt.SetActive(true);
            black.SetActive(true);
            Invoke("StartDiary", 1);
            //diary_Text.SetActive(true);
        }

    }
    void StartDiary()
    {
        diary_Text.SetActive(true);
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            //diary_Button.SetActive(false);
            keyPrompt.SetActive(false);
            diary_Text.SetActive(false);
            coll.enabled = false;
        }
    }*/
    private void Update()
    {

        /*if (keyPrompt.activeSelf &&Input.GetKeyDown(KeyCode.Tab))
        {
            //diary_Button.SetActive(true);
            diary_Text.SetActive(true);
            keyPrompt.SetActive(false);
            Time.timeScale = 0;
        }*/


        //if (diary_Text.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //diary_Button.SetActive(true);
        //    diary_Text.SetActive(false);
         
        //    Time.timeScale = 0;
        //}


    }

}
