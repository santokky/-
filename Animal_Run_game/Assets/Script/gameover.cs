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
            gameState.text = "최고 점수 : "+GameManager.instance.score+"<br>게임 오버, R키를 눌러 다시 시작";
            restart();
        }
        
    }

    void restart() {
        if (Input.GetKey(KeyCode.R))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            // 현재 씬을 다시 로드합니다.
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
