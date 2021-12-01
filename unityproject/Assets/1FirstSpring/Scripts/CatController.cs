using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public GameObject longButtonF;
    public GameObject cat_ButtonF;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
            if (collision.tag == "Player")
            {

                Invoke("StartLongButton", 3);
                //longButtonF.SetActive(true);
            }
        */

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            if (collision.tag == "Player"||Input.GetKeyDown(KeyCode.F))
            {
                longButtonF.SetActive(false);
            }

        

    }


    void StartLongButton()
    {
        longButtonF.SetActive(true);
    }

}
