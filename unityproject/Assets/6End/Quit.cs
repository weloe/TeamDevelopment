using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMenu", 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
