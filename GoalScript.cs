using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject frog;
    public static bool Killorwin=false;
    private void OnEnable()
    {
        frog.SetActive(true);
    }

    private void OnDisable()
    {
        frog.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Froggy")
        {
            frog.SetActive(true);
            MainScript.pontos += 1000;
            StartCoroutine("TimeRespawn");
            
        }
    }

    IEnumerator TimeRespawn()
    {
        FroggyMove.Live = false;
        yield return new WaitForSeconds(0.9f);
        FindObjectOfType<FroggyMove>().Respawn();
        FroggyMove.Live = true;
    }
}
