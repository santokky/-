using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private void Update()
    {
        RestartScene();
    }
    public void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("mainGame");
    }
}
