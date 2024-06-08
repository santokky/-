using UnityEngine;
using UnityEngine.UI;

public class FastterButton : MonoBehaviour
{
    private float originalTimeScale; // 원래 Time.timeScale 값 저장

    public float timeScaleMultiplier = 2f; // 시간 배속 값

    private bool isButtonPressed = false; // 버튼을 누르고 있는지 여부를 저장하는 변수

    public Button speedButton; // 인터페이스에서 버튼을 할당할 변수

    // 게임 시작 시 호출될 함수
    private void Start()
    {
        originalTimeScale = Time.timeScale; // 원래 Time.timeScale 값 저장
        speedButton.onClick.AddListener(OnButtonClicked); // 버튼 클릭 이벤트에 함수 연결
    }

    // 버튼을 누를 때 호출될 함수
    private void OnButtonClicked()
    {
        isButtonPressed = !isButtonPressed; // 버튼을 누르거나 떼는 상태로 변경

        if (isButtonPressed)
        {
            Time.timeScale = timeScaleMultiplier; // 시간 배속 적용
        }
        else
        {
            Time.timeScale = originalTimeScale; // 원래 Time.timeScale 값으로 복원
        }
    }
}
