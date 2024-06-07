using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class select_button : MonoBehaviour
{
    Animator animator;
    bool canSelect = true;
    

    void Start()
    {
        canSelect = true;

        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        Button button = GetComponent<Button>();
        animator = GameManager.instance.main_UI.transform.GetComponent<Animator>();
        
        if (button != null && canSelect)
        {
            button.onClick.AddListener(PlayAnimation);
        }
    }
    
    void PlayAnimation()
    {
        GameManager.instance.abilitySetting(int.Parse(this.name));
        // �ִϸ��̼��� �����Ű�� �ڵ�
        if (animator != null)
        {
            animator.Play("up_selection"); // �ִϸ��̼� Ʈ���� �̸� ���
            canSelect = false;
            Time.timeScale = GameManager.instance.gameTime;
        }
    }
}
