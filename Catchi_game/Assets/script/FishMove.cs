using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed = 3f; // ������� �̵� �ӵ�
    public float swimDuration = 2f; // ���ġ�� �ð�
    public float idleDuration = 1f; // ������ �ִ� �ð�
    private float xMin, xMax, yMin, yMax;

    private Rigidbody2D rb;
    private Vector2 swimDirection;
    private float timer;
    private bool isSwimming;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        swimDirection = Random.insideUnitCircle.normalized;
        isSwimming = true;
        timer = swimDuration;
        xMax = 5;
        xMin = -5;
        yMax = 0;
        yMin = -3;
    }

    private void Update()
    {
        idleDuration = Random.Range(1f, 3f);
        if (isSwimming)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                isSwimming = false;
                timer = idleDuration;
                rb.velocity = Vector2.zero;
            }
            else
            {
                float currentLocation = transform.position.x;
                rb.velocity = swimDirection * moveSpeed;
                if (rb.velocity.x < 0)
                {
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else if (rb.velocity.x >= 0)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                isSwimming = true;
                timer = swimDuration;
                swimDirection = Random.insideUnitCircle.normalized;
            }
        }
    }
    private void FixedUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}