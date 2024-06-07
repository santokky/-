using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour
{
    Animator ani;
    BoxCollider2D col;
    SpriteRenderer spriteRenderer;

    bool noPain = true;

    // Start is called before the first frame update
    void Start()
    {
        ani = transform.GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && gameObject.CompareTag("Player") && noPain)
        {
            if (Random.Range(0, 100) < GameManager.instance.power)
            {
                Destroy(collision.gameObject);
            }
            else 
            {
                Debug.Log("ºÎµúÈû");
                GameManager.instance.hp -= 150f;
                StartCoroutine(waitingSecond(1.5f * Time.timeScale));
            }
        }
    }

    IEnumerator waitingSecond(float duration) {

        noPain = false;

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

        yield return new WaitForSeconds(duration);

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f);
        noPain = true;
    }

}
