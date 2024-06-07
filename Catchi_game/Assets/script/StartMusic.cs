using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    AudioSource BGM;
    bool musicStart = false;

    private void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (!musicStart)
        {
            if (Other.CompareTag("Arrows"))
            {
                BGM.Play();
                musicStart = true;
            }
        }
    }
}
