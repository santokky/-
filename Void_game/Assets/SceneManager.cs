using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    // 원하는 해상도
    public int targetWidth = 1000;
    public int targetHeight = 1000;

    void Start()
    {
        // 원하는 해상도로 설정
        Screen.SetResolution(targetWidth, targetHeight, fullscreen: false);
    }
}
