using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expBar : MonoBehaviour
{
    float expLate;
    private RectTransform bar;
    float barSize;

    // Start is called before the first frame update
    void Start()
    {
        expLate = (float) GameManager.instance.EXP / (float) GameManager.instance.MaxEXP;
        bar = transform.GetComponent<RectTransform>();
        barSize = bar.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        expLate = (float)GameManager.instance.EXP / (float)GameManager.instance.MaxEXP;
        bar.sizeDelta = new Vector2(expLate * barSize, bar.sizeDelta.y);
    }
}
