using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    public GameObject diary_ButtonF;
    public GameObject diary_Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            diary_ButtonF.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            diary_ButtonF.SetActive(false);
            diary_Text.SetActive(false);
        }
    }
    private void Update()
    {
        if(diary_ButtonF.activeSelf&&Input.GetKeyDown(KeyCode.Tab))
        {
            diary_Text.SetActive(true);
        }
    }

}
