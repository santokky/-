using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class abilityDisplay : MonoBehaviour
{
    private TMP_Text ability;

    // Start is called before the first frame update
    void Start()
    {
        ability = transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ability.text = "�ִ� ü�� : " + GameManager.instance.maxHP.ToString() + "<br>"
            + "�ִ� ȸ���� : " + GameManager.instance.healPower.ToString() + "<br>"
            + "�ӵ� : " + GameManager.instance.gameTime.ToString() + "<br>"
            + "�ı� Ȯ�� : " + GameManager.instance.power.ToString() + "<br>"
            + "�ڼ� �ɷ� : " + GameManager.instance.magnet.ToString();
    }
}
