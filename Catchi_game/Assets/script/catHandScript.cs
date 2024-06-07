using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catHandScript : MonoBehaviour
{
    private Animator anim;
    public static catHandScript instance;
    bool cutting, mistaking;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void cut() {
        cutting = true;
    }

    public void mistake() {
        mistaking = true;
    }

    public void execute()
    {
        if (cutting)
        {
            anim.SetTrigger("cutting");
            cutting = false;
        }
        else if (mistaking) {
            anim.SetTrigger("mistaking");
            mistaking = false;
        }
    }
}
