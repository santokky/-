using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowSize : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Screen.SetResolution(1164, 604, true);
    }
}
