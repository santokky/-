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
        ability.text = "최대 체력 : " + GameManager.instance.maxHP.ToString() + "<br>"
            + "최대 회복률 : " + GameManager.instance.healPower.ToString() + "<br>"
            + "속도 : " + GameManager.instance.gameTime.ToString() + "<br>"
            + "파괴 확률 : " + GameManager.instance.power.ToString() + "<br>"
            + "자석 능력 : " + GameManager.instance.magnet.ToString();
    }
}
