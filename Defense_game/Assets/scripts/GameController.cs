using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;

    public bool stageStart;
    public bool stageState = true;
    public Text stageClear;

    public Text gold;
    private int currentMoney = 0;

    public Text score;
    private int addScore = 0;

    public Text[] synergy;
    public int Ice = 0;
    public int IceMin = 15;
    public int fire = 0;
    public int fireMin = 10;
    public int chain = 0;
    public int chainMin = 10;

    public Text heart;
    public int heartValue = 10;
    private bool gameRestart = false;

    public int tileCount1 = 1;
    public int tileCount2 = 1;
    public int tileCount3 = 1;
    public int tileCount4 = 1;
    public int tileCount5 = 1;

    private AudioSource stageClearAudio;

    private void Awake()
    {
        stageClearAudio = GetComponent<AudioSource>();
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        gameover();
        updateSynergy();
    }

    public static GameController Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void changeMoney(int monsterValue)
    {
        currentMoney = int.Parse(gold.text);
        currentMoney += monsterValue;
        gold.text = "" + currentMoney;

        addScore = int.Parse(score.text);
        addScore += monsterValue;
        score.text = "" + addScore;
    }

    public void changeHeart()
    {
        heartValue--;
        if (heartValue <= 0) {
            heartValue = 0;
        }
        heart.text = "" + heartValue;
    }

    public void gameover() {
        if (heartValue == 0) {
            stageClear.text = "���� ���� \nPress 'S' to restart";
            gameRestart = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && gameRestart) {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainGame");
        }
    }

    public void stageClearText(bool value) {
        if (value)
        {
            stageClearAudio.Play();
            stageClear.text = "�������� Ŭ���� \nPress 'V' to play next stage";
        }
        else {
            stageClear.text = "";
        }

    }

    private void updateSynergy() {
        if (fire < fireMin)
        {
            synergy[0].text = "ȭ�� : " + fire + " / " + fireMin;
        }
        else
        {
            synergy[0].text = "ȭ�� Ȱ��ȭ!";
        }
        if (Ice < IceMin)
        {
            synergy[1].text = "���� : " + Ice + " / " + IceMin;
        }
        else
        {
            synergy[1].text = "���� Ȱ��ȭ!";
        }
        if (chain < chainMin)
        {
            synergy[2].text = "���� : " + chain + " / " + chainMin;
        }
        else
        {
            synergy[2].text = "���� Ȱ��ȭ!";
        }
    }

    public void returnSpawnCount()
    {
        tileCount1 = 1;
        tileCount2 = 1;
        tileCount3 = 1;
        tileCount4 = 1;
        tileCount5 = 1;
    }
}
