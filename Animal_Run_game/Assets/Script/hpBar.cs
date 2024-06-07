using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBar : MonoBehaviour
{
    float HPLate;
    private RectTransform bar;
    float barSize;

    // Start is called before the first frame update
    void Start()
    {
        HPLate = (float)GameManager.instance.hp / (float)GameManager.instance.maxHP;
        bar = transform.GetComponent<RectTransform>();
        barSize = bar.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        hpDown();
        HPLate = (float)GameManager.instance.hp / (float)GameManager.instance.maxHP;
        bar.sizeDelta = new Vector2(HPLate * barSize, bar.sizeDelta.y);
        GameManager.instance.gameover();
    }

    void hpDown() {
        if (Time.timeScale != 0) {
            GameManager.instance.hp -= GameManager.instance.armor * (GameManager.instance.playerLevel / 5 + 1) * Time.deltaTime / Time.timeScale;
        }
    }
}
