using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemLocation : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = transform.GetChild(0).position;
    }
}
