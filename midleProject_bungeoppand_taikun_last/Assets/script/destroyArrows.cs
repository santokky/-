using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyArrows : MonoBehaviour
{
    public float moveSpeed = 0.25f;
    public float moveDirection = 1;
    public static destroyArrows instance;
    private int destroyCnt = 1;

    public GameObject fail;
    private Rigidbody2D rb;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void diretion(int a) {
        moveDirection = a;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.position.x >= 9f) {
            moveDirection = -1;
        }
        if (rb.position.x <= -9f)
        {
            moveDirection = 1;
        }
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    public void initDestroyCnt() {
        destroyCnt = 0;
    }

    public int returnDestroyCnt() {
        return destroyCnt;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(fail, transform.position, transform.rotation);
        Destroy(other.gameObject);
        destroyCnt++;
    }
}
