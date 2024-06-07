using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelDisplay : MonoBehaviour
{
    private TMP_Text level;

    // Start is called before the first frame update
    void Start()
    {
        level = transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        level.text = GameManager.instance.playerLevel.ToString();
    }
}
