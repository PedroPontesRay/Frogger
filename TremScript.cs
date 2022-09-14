using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TremScript : MonoBehaviour
{
    //Move Velocity
    public float velocity;

    //Position Warp
    public float WarpPosicionX;
    public float WarpPosicionY;

    //Side
    public string Side;



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



}
