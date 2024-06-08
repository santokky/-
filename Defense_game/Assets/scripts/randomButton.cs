using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomButton : MonoBehaviour
{
    int randomNumber;
    private int selectTower = 0;
    public Sprite[] spriteOptions;
    private Image buttonImage;
    private int[] percentage = {0, 35, 65, 84, 98, 99};
    private int towerValue = 0;
    private int ice, fire, chain;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = this.GetComponent<Image>();
        color = buttonImage.color;
        RandomButtonSprite();
    }

    public void RandomButtonSprite() {
        randomNumber = Random.Range(0, 100);

        if (randomNumber >= percentage[0] && randomNumber < percentage[1])
        {
            selectTower = 0;
            towerValue = 5;
            buttonImage.sprite = spriteOptions[0];
            spriteAlphaReturn();
        }
        else if (randomNumber >= percentage[1] && randomNumber < percentage[2])
        {
            selectTower = 1;
            towerValue = 10;
            buttonImage.sprite = spriteOptions[1];
            spriteAlphaReturn();
        }
        else if (randomNumber >= percentage[2] && randomNumber < percentage[3])
        {
            selectTower = 2;
            towerValue = 15;
            buttonImage.sprite = spriteOptions[2];
            spriteAlphaReturn();
        }
        else if (randomNumber >= percentage[3] && randomNumber < percentage[4])
        {
            selectTower = 3;
            towerValue = 20;
            buttonImage.sprite = spriteOptions[3];
            spriteAlphaReturn();
        }
        else
        {
            selectTower = 4;
            towerValue = 25;
            buttonImage.sprite = spriteOptions[4];
            spriteAlphaReturn();
        }
    }

    public int returnTowerNum() {
        return selectTower;
    }

    public int returnTowerValue()
    {
        return towerValue;
    }

    public void spriteAlphaReturn() {
        Color newColor = buttonImage.color;
        newColor.a = 1f;
        buttonImage.color = newColor;
    }

    public void spriteAlphaReduce() {
        Color newColor = buttonImage.color;
        newColor.a = 0.5f;
        buttonImage.color = newColor;
    }
}
