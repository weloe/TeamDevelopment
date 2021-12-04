using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogSystem : MonoBehaviour
{
    public Text textLabel;
    public Image faceImage;

    //[SerializeField]private GameObject player;

    public TextAsset textFile;
    public int index;

    public GameObject black;



    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {

        
        GetTextFromFile(textFile);//���txt�ļ�
        //index = 0;
    }
    void GetTextFromFile(TextAsset file)
    {

        
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');//�����и���һ������
        foreach (var line in lineData)
        {
            textList.Add(line);
        }

    }



    private void OnEnable()//Onenable��Startǰ����,Awake��
    {
        textLabel.text = textList[index];//�����һ��
        //index++;
    }



    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            index = index + 1;
            textLabel.text = textList[index];
            //index++;

        }
        if(Input.GetKeyDown(KeyCode.A) && index>=1)
        {
            index = index - 1;
            textLabel.text = textList[index];
            
        }

        if ((Input.GetKeyDown(KeyCode.D) && index == textList.Count - 1) || Input.GetKeyDown(KeyCode.Escape))//index ==5
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            index = 0;
            Invoke("StartBlack", 0);
            Invoke("LoadNext", 1);


            return;
            

        }
        


    }
    void StartBlack()
    {
        black.SetActive(true);
    }
    void LoadNext()
    {
        SceneManager.LoadScene("2FirstSummer");
    }


}