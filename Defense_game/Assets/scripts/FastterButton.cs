using UnityEngine;
using UnityEngine.UI;

public class FastterButton : MonoBehaviour
{
    private float originalTimeScale; // ���� Time.timeScale �� ����

    public float timeScaleMultiplier = 2f; // �ð� ��� ��

    private bool isButtonPressed = false; // ��ư�� ������ �ִ��� ���θ� �����ϴ� ����

    public Button speedButton; // �������̽����� ��ư�� �Ҵ��� ����

    // ���� ���� �� ȣ��� �Լ�
    private void Start()
    {
        originalTimeScale = Time.timeScale; // ���� Time.timeScale �� ����
        speedButton.onClick.AddListener(OnButtonClicked); // ��ư Ŭ�� �̺�Ʈ�� �Լ� ����
    }

    // ��ư�� ���� �� ȣ��� �Լ�
    private void OnButtonClicked()
    {
        isButtonPressed = !isButtonPressed; // ��ư�� �����ų� ���� ���·� ����

        if (isButtonPressed)
        {
            Time.timeScale = timeScaleMultiplier; // �ð� ��� ����
        }
        else
        {
            Time.timeScale = originalTimeScale; // ���� Time.timeScale ������ ����
        }
    }
}
