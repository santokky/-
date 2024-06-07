using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBackward : MonoBehaviour
{
    float speed;

    // Update is called once per frame
    void Update()
    {
        speed = GameManager.instance.speed;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
