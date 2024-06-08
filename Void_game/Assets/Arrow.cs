using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    Vector3 arrowDir;

    float arrowSpeed;

    void Start()
    {
        arrowSpeed = 2f;

        player = GameObject.Find("표적");

        playerPos = player.transform.position;

        arrowDir = (playerPos - this.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += arrowDir * Time.deltaTime * arrowSpeed;

        Invoke("destroyArrow", 6f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("플레이어 맞음 피 -1");
            destroyArrow();
            Time.timeScale = 0;
        }
    }

    void destroyArrow() {
        Destroy(this.gameObject);
    }
}
