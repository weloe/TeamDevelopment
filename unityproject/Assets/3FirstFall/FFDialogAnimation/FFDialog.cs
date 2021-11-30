using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFDialog : MonoBehaviour
{
    public GameObject diary;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("revealDialog", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void revealDialog()
    {
        diary.SetActive(true);
    }
}
