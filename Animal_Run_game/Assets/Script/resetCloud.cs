using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCloud : MonoBehaviour
{
    Vector3 roadPosition;
    public float speedValue = 20f;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.instance.speed / speedValue;
        roadPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x <= -48f)
        {
            transform.position = new Vector3(0, 0, 0);
            roadPosition = this.transform.position;
        }
    }

}
