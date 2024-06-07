using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlayer : MonoBehaviour
{

    BoxCollider2D bc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.transform.position = new Vector2(-11.5f, 18f);
            GameManager.instance.hp -= GameManager.instance.maxHP * 0.4f;
        }
    }
}
