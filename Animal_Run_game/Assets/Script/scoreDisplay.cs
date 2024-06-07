using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDisplay : MonoBehaviour
{
    private TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.instance.score.ToString() + "Á¡";
    }
}
