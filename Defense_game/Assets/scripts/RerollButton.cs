using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RerollButton : MonoBehaviour
{
    public GameObject[] buttons;
    public Text goldValue;
    public Text alertMoney;
    int currentMoney = 0;
    public float fadeDuration = 0.6f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            MoneyCheck();
        }
    }

    public void MoneyCheck()
    {
        currentMoney = int.Parse(goldValue.text);
        if (currentMoney < 5)
        {
            StartCoroutine(FadeText());
        }
        else
        {
            currentMoney -= 5;
            goldValue.text = "" + currentMoney;
            Reroll();
            GameController.Instance.returnSpawnCount();
        }
    }

    private IEnumerator FadeText()
    {
        alertMoney.color = new Color(alertMoney.color.r, alertMoney.color.g, alertMoney.color.b, 0.1f);

        yield return new WaitForSeconds(0.1f);

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // 1부터 0까지 알파 값 보간
            float alpha = Mathf.Lerp(1f, 0f, normalizedTime);
            alertMoney.color = new Color(alertMoney.color.r, alertMoney.color.g, alertMoney.color.b, alpha);

            yield return null;
        }
    }

    public void Reroll() { 
        foreach(GameObject button in buttons){
            button.GetComponent<randomButton>().RandomButtonSprite();
        }
    }
}
