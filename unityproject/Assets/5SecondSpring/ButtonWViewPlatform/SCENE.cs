using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Load",8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Load()
    {
        SceneManager.LoadScene("Cemetery");
    }
}
