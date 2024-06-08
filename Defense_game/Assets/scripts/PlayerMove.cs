using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;
    // Transform ���� ī�޶� �����ӿ� ���� �޶��� , �ش� ���� ī�޶� ��� �Ѱ��ֱ� .
    public CharacterController characterController;
    // ĳ���� �ݶ��̴��� 3D ������Ʈ�� �����ϱ� ���� ���� ����.
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = -20f;
    public float yVelocity = 0;
    // y�� ������.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);
        // x,y,z �� = h,0,v �������� �о�� vector3�� ���� �ش簪�� moveDirection�� �ѱ�

        moveDirection = cameraTransform.TransformDirection(moveDirection);
        // ī�޶� ��ġ

        moveDirection *= moveSpeed;
        // ���ǵ� ���ؼ� ���� �� ����

        if (characterController.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
                // y ���� �������ǵ�� �Ѱܼ� ó��
            }
        }
        yVelocity += (gravity * Time.deltaTime);
        // y ���� �߷°� * Time.deltaTime ( Time.detaTime �����Ű�� ������Ʈ �Լ��� �Լ� �ݺ��Ǹ鼭 ����Ǵµ� ������Ʈ �Լ��� ����ǰ� �ٽ� ����Ǵ� �� ������ �ð��� Time.deltaTime �Լ��� )

        moveDirection.y = yVelocity;
        // ����� y ���� moveDirection.y ( y�� ������ ���� ) ���� �Ѱ���

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
