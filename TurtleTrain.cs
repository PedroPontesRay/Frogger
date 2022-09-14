using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTrain : MonoBehaviour
{


    //Move Velocity
    public float velocity;

    //Position Warp
    public float WarpPosicionX;
    public float WarpPosicionY;

    //Side
    public string Side;

    public BoxCollider2D Collider;
    public SpriteRenderer[] childRenderers;

    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        childRenderers = GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine("TimeForEnable");
    }

    void Update()
    {
        switch (Side)
        {
            case "Right":
                transform.Translate(Vector2.right * velocity * Time.deltaTime);
                break;
            case "Left":
                transform.Translate(Vector2.left * velocity * Time.deltaTime);
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Teleport When He Get's Warp contact
        if (collision.gameObject.tag == "Warp")
        {
            transform.position = new Vector2(WarpPosicionX, WarpPosicionY);
        }
    }

    IEnumerator TimeForEnable()
    {

        //Possivel pular
        Collider.enabled = true;

        foreach (SpriteRenderer childRenderer in childRenderers)
        {
            childRenderer.color = Color.yellow;
        }



        yield return new WaitForSeconds(3.0f);

        //Não pode pular
        Collider.enabled = false;

        foreach (SpriteRenderer childRenderer in childRenderers)
        {
            childRenderer.color = Color.blue;
        }

        yield return new WaitForSeconds(3.0f);

        StartCoroutine("TimeForEnable");
    }

}
