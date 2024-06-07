using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;

public class GameManager : MonoBehaviour
{
    //String으로 수식 계산
    DataTable dt;

    // 싱글톤 패턴
    public static GameManager instance = null;
    public GameObject main_UI;
    public float gameTime = 1f;

    //캐릭터의 능력치
    [Header ("#level")]
    public int playerLevel = 1;

    [Header ("#HP")]
    public float maxHP = 1000f;
    public float hp;
    public float healPower = 1.0f;

    [Header("#speed")]
    public float speed = -20f;

    [Header("#power")]
    public float power = 10f;

    [Header("#armor")]
    public float armor = 20f;

    [Header("#magnet")]
    public float magnet = 0f;

    [Header("#gravity")]
    //중력
    public float gravityScale = 7.0f;
    public float jumpForce = 28.0f;

    [Header("#exp")]
    //경험치, 최대 경험치
    public int MaxEXP = 100;
    public int EXP = 0;
    public float expValue = 1;
    public int score = 0;

    //아이템들
    public ItemData[] itemDatas;

    private void Awake()
    {
        Time.timeScale = 1f;

        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        hp = maxHP;
    }

    public bool levelUp() {
        if (MaxEXP <= EXP) {
            playerLevel++;
            if (hp + 200 > maxHP)
            {
                hp = maxHP;
            }
            else 
            {
                hp += 200;
            }
            MaxEXP = (int) ((1 + (Mathf.Log(playerLevel, 10))) * 100);
            EXP = 0;
            return true;
        }
        return false;
    }

    public void abilitySetting(int itemID)
    {
        dt = new DataTable();

        if (itemDatas[itemID].itemtype.ToString() == "maxHP")
        {
            maxHP += itemDatas[itemID].baseAbility;
            hp += itemDatas[itemID].baseAbility * healPower;
            power += itemDatas[itemID].bonusScore;
        }
        else if (itemDatas[itemID].itemtype.ToString() == "speed")
        {
            gameTime *= itemDatas[itemID].baseAbility;
        }
        else if (itemDatas[itemID].itemtype.ToString() == "power")
        {
            power += itemDatas[itemID].baseAbility;
            score += (int) itemDatas[itemID].bonusScore;
        }
        else if (itemDatas[itemID].itemtype.ToString() == "armor")
        {
            armor *= itemDatas[itemID].baseAbility;
            healPower *= itemDatas[itemID].bonusScore;
        }
        else if (itemDatas[itemID].itemtype.ToString() == "hp")
        {
            if ((hp + itemDatas[itemID].baseAbility) >= maxHP)
            {
                hp = maxHP;
                score += (int) itemDatas[itemID].bonusScore;
            }
            else
            {
                hp += itemDatas[itemID].baseAbility * healPower;
                score += (int)itemDatas[itemID].bonusScore;
            }
        }
        else if (itemDatas[itemID].itemtype.ToString() == "exp")
        {
            expValue += itemDatas[itemID].baseAbility;
        }
        else if (itemDatas[itemID].itemtype.ToString() == "magnet") 
        {
            magnet += (int)itemDatas[itemID].baseAbility;
        }
    }

    public bool gameover() {
        if (hp <= 0)
        {
            Time.timeScale = 0;
            return true;
        }
        else 
        {
            return false;
        }
    }
}
