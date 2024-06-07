using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playGame : MonoBehaviour
{
    private void Update()
    {
        NextScene();
    }
    public void NextScene()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SceneManager.LoadScene("mainGame");
    }
}
