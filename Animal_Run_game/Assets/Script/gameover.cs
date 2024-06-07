using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class gameover : MonoBehaviour
{
    TMP_Text gameState;

    private void Start()
    {
        gameState = GetComponent<TMP_Text>();

    }

    void Update()
    {
        if (GameManager.instance.gameover()) {
            gameState.text = "�ְ� ���� : "+GameManager.instance.score+"<br>���� ����, RŰ�� ���� �ٽ� ����";
            restart();
        }
        
    }

    void restart() {
        if (Input.GetKey(KeyCode.R))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            // ���� ���� �ٽ� �ε��մϴ�.
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
