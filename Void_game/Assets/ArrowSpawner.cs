using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    float x, y, angle, radius;
    public GameObject arrow;
    // Update is called once per frame
    void Start()
    {
        radius = 6f;

        InvokeRepeating("arrowSpawn", 1f, 1f);
        InvokeRepeating("arrowSpawn", 2f, 1f); 
        InvokeRepeating("arrowSpawn", 4f, 1f);
        InvokeRepeating("arrowSpawn", 8f, 1f);
        InvokeRepeating("arrowSpawn", 16f, 1f);
        InvokeRepeating("arrowSpawn", 32f, 1f);
        InvokeRepeating("arrowSpawn", 32f, 1f);
        InvokeRepeating("arrowSpawn", 64f, 1f);
        InvokeRepeating("arrowSpawn", 64f, 1f);
        InvokeRepeating("arrowSpawn", 64f, 1f);
    }

    void arrowSpawn() {
        angle = Random.Range(0, 360);

        x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        Instantiate(arrow, new Vector2(x, y), Quaternion.identity);

    }
}
