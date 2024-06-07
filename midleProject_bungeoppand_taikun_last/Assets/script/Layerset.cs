using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layerset : MonoBehaviour
{
    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        this.spriterenderer = this.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "head") this.spriterenderer.sortingOrder = 2;
        else if (this.tag == "body") this.spriterenderer.sortingOrder = 4;
        else if (this.tag == "thorn") this.spriterenderer.sortingOrder = 1;
        else if (this.tag == "tail") this.spriterenderer.sortingOrder = 2;
    }
}
