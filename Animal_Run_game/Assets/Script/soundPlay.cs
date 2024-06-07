using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlay : MonoBehaviour
{
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = transform.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audiosource.Play();
    }
}
