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

        // 버튼에 클릭 이벤트 리스너 추가
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
        // 애니메이션을 실행시키는 코드
        if (animator != null)
        {
            animator.Play("up_selection"); // 애니메이션 트리거 이름 사용
            canSelect = false;
            Time.timeScale = GameManager.instance.gameTime;
        }
    }
}
