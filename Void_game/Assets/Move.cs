using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 newPos;
    Vector3 backPos;

    float speed;

    float radius;

    private void Start()
    {
        radius = 3f;
        speed = 5f;

        newPos = transform.position; // 현재 위치로 초기화
    }

    private void Update()
    {
        if (Mathf.Sqrt(newPos.x * newPos.x + newPos.y * newPos.y) < radius)
        {
            newPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            newPos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.position = newPos;
        }
        else {
            backPos = new Vector2(-newPos.x, -newPos.y).normalized * 0.1f;
            newPos = new Vector2(newPos.x + backPos.x, newPos.y + backPos.y);
        }
    }
}
