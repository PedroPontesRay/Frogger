using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public static SpriteRenderer RendererAcess;
    void Start()
    {
        RendererAcess = GetComponent<SpriteRenderer>();
        RendererAcess.color = Color.yellow;
    }
}
