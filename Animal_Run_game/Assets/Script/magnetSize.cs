using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetSize : MonoBehaviour
{
    CircleCollider2D cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cc.radius = GameManager.instance.magnet;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("exp"))
        {
            collision.transform.position = Vector3.Lerp(collision.transform.position, transform.position, GameManager.instance.magnet * Time.deltaTime);
            Debug.Log("자석 범위 안");
        }

    }
}
