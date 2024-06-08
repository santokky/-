using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public Camera firstperson;
    public Camera thirdperson;
    bool cam_check = false;
    public float width;
    public float height;
    public GameObject aimImage;
    public GameObject rerollPanel;
    public GameObject fasterButton;

    private void Awake()
    {
        firstperson.enabled = true;
        thirdperson.enabled = true;
        Showfirstperson();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.V) && cam_check == true && GameController.Instance.stageState == true)
        {
            Time.timeScale = 1f;
            GameController.Instance.stageStart = false;
            GameController.Instance.stageClearText(false);
            Showfirstperson();
            aimImage.SetActive(cam_check);
            rerollPanel.SetActive(cam_check);
            fasterButton.SetActive(false);
            cam_check = false;
            GameController.Instance.stageState = true;
        }
        else if (Input.GetKeyDown(KeyCode.V) && cam_check == false && GameController.Instance.stageState == true)
        {
            GameController.Instance.stageStart = true;
            GameController.Instance.stageState = false;
            Showthirdperson();
            aimImage.SetActive(cam_check);
            rerollPanel.SetActive(cam_check);
            fasterButton.SetActive(true);
            cam_check = true;
        }
    }
    void Showfirstperson()
    {
        thirdperson.rect = new Rect(width, width, height, height);
        firstperson.rect = new Rect(0, 0, 1, 1);
        thirdperson.depth = 1;
        firstperson.depth = -1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Showthirdperson()
    {
        firstperson.rect = new Rect(width, width, height, height);
        thirdperson.rect = new Rect(0, 0, 1, 1);
        thirdperson.depth = -1;
        firstperson.depth = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
