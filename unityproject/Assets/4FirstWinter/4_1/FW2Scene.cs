using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FW2Scene : MonoBehaviour
{
    public GameObject black;
    public GameObject diary;
    public Animator anim;
    public GameObject car;
    public GameObject carCheck;

    private void Start()
    {
        diary.SetActive(true);
        anim.SetBool("fadeIn", true);
        anim.SetBool("fadeOut", false);
        car.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (!diary.activeSelf)
        {
            anim.SetBool("fadeOut", true);
            car.SetActive(true);
        }

        if (car.transform.position.x >= carCheck.transform.position.x)
        {
            anim.SetBool("fadeIn", true);
            Invoke("Load", 1);
        }
    }
    void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
