using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggyMove : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D cd;
    public Vector3 BeginPosition = new Vector2(0, -4.5f);

    public bool OnTrunk = false;
    public static bool Live = true;

    private float farthestRow;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();

        Respawn();
    }

    void Update()
    {
        if(transform.position == BeginPosition)
        {
            farthestRow = -4.5f;
        }

        if(transform.position.y > farthestRow)
        {
            farthestRow = transform.position.y;
            FindObjectOfType<MainScript>().UpPoints();
        }

        // declaração de movimento
        if(Live)
        {
            //block the out of map
            if (transform.position.x > -8)
            {
                //Move to Left
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-1, 0);
                }
            }
            //block the out of map
            if (transform.position.y != 3.5f)
            {
                //Move UP
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position += new Vector3(0, 1);
                }
            }
            //block the out of map
            if (transform.position.x < 8)
            {
                //Move Right
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(1, 0);
                }
            }
            //block the out of map
            if (transform.position.y != -4.5f)
            {
                //Move Down
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position += new Vector3(0, -1);
                }
            }
            
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Move when the froggy enter the Trunk
        if (collision.gameObject.tag == "Trunk")
        {
            OnTrunk = true;   
            transform.parent = collision.transform;
        }

        //Kill and return the Begin position
        if (collision.gameObject.tag == "Train")
        {
            Dead();
        }

        //Win register
        if(collision.gameObject.tag == "Win")
        {
            Respawn();
            MainScript.pontos += 1000;
        }

        if(collision.gameObject.tag == "Water")
        {
            StartCoroutine("CorrotineTrunk");
        }
    }

    //Remove Froggy from trunk
    private void OnTriggerExit2D(Collider2D other)
    {
        OnTrunk = false;
        transform.parent = null;
        StartCoroutine("CorrotineTrunk");
    }

    public void Dead()
    {
        //morto
        Live = false;
        MainScript.CancelDeath = true;

        //corrotina para voltar para o inicio
        StartCoroutine("CorrotineDeath");

        //desativa
        cd.enabled = false;
    }

    IEnumerator CorrotineDeath()
    {  
        yield return new WaitForSeconds(0.5f);
        //return to begin position
        Respawn();
        cd.enabled = true;
        Live = true;
    }

    IEnumerator CorrotineTrunk()
    {

        yield return new WaitForSeconds(0.1f);
        if (Live)
        {
            if (OnTrunk == false && (transform.position.y > 1.98f && transform.position.y < 2.83f))
            {
              Dead();
                print("...");
            }
        }
    }

    public void Respawn()
    {
        transform.position = BeginPosition;
    }

}