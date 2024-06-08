using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float sense = 500f;
    public float rotationX;
    public float rotationY;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        rotationY += mouseMoveX * sense * Time.deltaTime;
        rotationX += mouseMoveY * sense * Time.deltaTime;

        // �� , �Ʒ��� �� 35�� �̻� �� ���� �Ѱ� ���� ..
        if (rotationX > 35f)
        {
            rotationX = 35f;
        }
        if (rotationX < -30f)
        {
            rotationX = -30f;
        }
        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}
