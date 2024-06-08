using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAim : MonoBehaviour
{
    public GameObject rerollPanel;
    public Image currentImg;
    public Sprite saveImg;

    private void Start()
    {
        currentImg = this.GetComponent<Image>();
        saveImg = currentImg.sprite;
    }

    private void Update()
    {
        getSprite();
    }

    void getSprite() {
        if (saveImg == currentImg.sprite)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Image buttonImg = rerollPanel.transform.GetChild(0).GetComponent<Image>();
                currentImg.sprite = buttonImg.sprite;
                buttonImg.sprite = null;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) 
            {
                Image buttonImg = rerollPanel.transform.GetChild(1).GetComponent<Image>();
                currentImg.sprite = buttonImg.sprite;
                buttonImg.sprite = null;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Image buttonImg = rerollPanel.transform.GetChild(2).GetComponent<Image>();
                currentImg.sprite = buttonImg.sprite;
                buttonImg.sprite = null;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Image buttonImg = rerollPanel.transform.GetChild(3).GetComponent<Image>();
                currentImg.sprite = buttonImg.sprite;
                buttonImg.sprite = null;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Image buttonImg = rerollPanel.transform.GetChild(4).GetComponent<Image>();
                currentImg.sprite = buttonImg.sprite;
                buttonImg.sprite = null;
            }
        }
        else
        {
            return;
        }
    }
}
