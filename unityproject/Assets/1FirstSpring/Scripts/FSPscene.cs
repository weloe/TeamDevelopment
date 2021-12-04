using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FSPscene : MonoBehaviour
{
    public GameObject black;
    public GameObject diary;
    public Animator anim;
    

    private void Start()
    {
        diary.SetActive(true);
        
        

    }
    // Update is called once per frame
    void Update()
    {
        if (!diary.activeSelf)
        {
            anim.SetBool("fadeOut", true);
            
        }

        
    }
    
}
