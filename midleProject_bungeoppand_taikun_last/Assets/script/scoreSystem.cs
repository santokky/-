using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreSystem : MonoBehaviour
{
    public static scoreSystem instance;
    public TMP_Text scoreText;
    public float score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void updateScore(float time)
    {
        score += 2000 / time;
    }

    private void Update()
    {
        UpdateCombo();
    }

    void UpdateCombo()
    {
        scoreText.text = "score: " + (int)score;
    }
}
