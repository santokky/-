using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    // ���ϴ� �ػ�
    public int targetWidth = 1000;
    public int targetHeight = 1000;

    void Start()
    {
        // ���ϴ� �ػ󵵷� ����
        Screen.SetResolution(targetWidth, targetHeight, fullscreen: false);
    }
}
