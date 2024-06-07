using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class item_information : MonoBehaviour
{
    //랜덤으로 아이템 뽑는 용도
    int random1, random2, random3;
    public ItemData[] itemDatas;
    public GameObject[] buttons;

    Image img1, img2, img3;
    TMP_Text name1, name2, name3;
    TMP_Text desc1, desc2, desc3;

    private void Start()
    {
        img1 = buttons[0].transform.GetChild(0).transform.GetComponent<Image>();
        img2 = buttons[1].transform.GetChild(0).transform.GetComponent<Image>();
        img3 = buttons[2].transform.GetChild(0).transform.GetComponent<Image>();

        name1 = buttons[0].transform.GetChild(1).transform.GetComponent<TMP_Text>();
        name2 = buttons[1].transform.GetChild(1).transform.GetComponent<TMP_Text>();
        name3 = buttons[2].transform.GetChild(1).transform.GetComponent<TMP_Text>();

        desc1 = buttons[0].transform.GetChild(2).transform.GetComponent<TMP_Text>();
        desc2 = buttons[1].transform.GetChild(2).transform.GetComponent<TMP_Text>();
        desc3 = buttons[2].transform.GetChild(2).transform.GetComponent<TMP_Text>();

        itemInfoSetting();
    }

    private void Update()
    {
        if (GameManager.instance.EXP == GameManager.instance.MaxEXP)
        {
            itemInfoSetting();
            Debug.Log("아이템 리셋");
        }
    }


    private void itemInfoSetting()
    {
        randomSetting();

        transform.GetChild(0).name = itemDatas[random1].itemId.ToString();
        transform.GetChild(1).name = itemDatas[random2].itemId.ToString();
        transform.GetChild(2).name = itemDatas[random3].itemId.ToString();


        img1.sprite = itemDatas[random1].itemIcon;
        img2.sprite = itemDatas[random2].itemIcon;
        img3.sprite = itemDatas[random3].itemIcon;

        name1.text = itemDatas[random1].itemName;
        name2.text = itemDatas[random2].itemName;
        name3.text = itemDatas[random3].itemName;

        desc1.text = itemDatas[random1].itemDesc;
        desc2.text = itemDatas[random2].itemDesc;
        desc3.text = itemDatas[random3].itemDesc;

        img1.SetNativeSize();
        img2.SetNativeSize();
        img3.SetNativeSize();
    }
    private void randomSetting()
    {
        random1 = Random.Range(1, itemDatas.Length - 1);
        random2 = Random.Range(0, random1);
        random3 = Random.Range(random1 + 1, itemDatas.Length);
    }

}
