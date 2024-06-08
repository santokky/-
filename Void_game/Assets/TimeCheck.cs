using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCheck : MonoBehaviour
{
    float scoreTime = 0;

    // Update is called once per frame
    void Update()
    {

        scoreTime += Time.deltaTime;
        this.gameObject.GetComponent<TMP_Text>().text = scoreTime.ToString("F2");

        if (Time.timeScale == 0) {
            this.gameObject.GetComponent<TMP_Text>().fontSize = 30;
            this.gameObject.GetComponent<TMP_Text>().color = Color.red;
            this.gameObject.GetComponent<TMP_Text>().text = "Game Over : " + scoreTime.ToString("F2") + "s Survival" + "\n Press 'R' to Restart";

            if (Input.GetKey(KeyCode.R)) {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
    }
}
