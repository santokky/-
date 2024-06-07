using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRoad : MonoBehaviour
{
    Vector3 roadPosition;
    public float speed = -0.05f;
    // Start is called before the first frame update
    void Start()
    {
        roadPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        roadPosition.x += speed;
        transform.position = roadPosition;
        if (transform.position.x <= -50f) {
            transform.position = new Vector3(0, -2, 0);
            roadPosition = this.transform.position;
        }
    }

}
