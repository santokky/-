using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exp_system : MonoBehaviour
{
    Animator ani;
    public ParticleSystem particle;

    // Start is called before the first frame update


    void Start()
    {
        ani = GameManager.instance.main_UI.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.levelUp())
        {
            Time.timeScale = 0f;
            ani.Play("down_selection");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Instantiate(particle, collision.transform.position, Quaternion.identity);
            GameManager.instance.EXP += (int) GameManager.instance.expValue;
            GameManager.instance.score += (int) (GameManager.instance.expValue * GameManager.instance.magnet * GameManager.instance.gameTime * 100);
            Destroy(this.gameObject);
        }
    }
}
