using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainScript : MonoBehaviour
{
    //varible to reacive points 
    public static int pontos;

    //recieve the text 
    public Text textoPontos;

    //Life System
    private int life;
    public GameObject[] Heart;
    public static bool CancelDeath;

    public static Color Enable;
    public static Color Disable;

    

    void Start()
    {
        pontos = 0;
        life = 3;
        CancelDeath= false;
    }
    void Update()
    {
        if (FroggyMove.Live==false && CancelDeath)
        {
            CancelDeath = false;
            life--;
        }
        switch (life)
        {
            case < 1:
                Destroy(Heart[0]);
                StartCoroutine("CorrotineReset");
                break;
            case < 2:
                Destroy(Heart[1]);
                break;
            case < 3:
                Destroy(Heart[2]);
                break;
        }

        //convert Number to text
        textoPontos.text = pontos.ToString();


    }

    //use the Reset Scene
    IEnumerator CorrotineReset()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameScene");
    }

    public void UpPoints()
    {
        pontos += 10;
    }

    


}
