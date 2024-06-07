using UnityEngine;

public class Fixed : MonoBehaviour
{
    public float targetAspectRatio = 16f / 9f;

    void Start()
    {
        UpdateResolution();
    }

    void Update()
    {
        if (Screen.width != (int)(Screen.height * targetAspectRatio))
        {
            UpdateResolution();
        }
    }

    void UpdateResolution()
    {
        int width = Screen.width;
        int height = (int)(width / targetAspectRatio);

        if (height > Screen.height)
        {
            height = Screen.height;
            width = (int)(height * targetAspectRatio);
        }

        Screen.SetResolution(width, height, false);
    }
}
