using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delectObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
