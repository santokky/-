using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;
    // Transform 값은 카메라 움직임에 따라 달라짐 , 해당 값을 카메라에 계속 넘겨주기 .
    public CharacterController characterController;
    // 캐릭터 콜라이더에 3D 오브젝트를 적용하기 위한 변수 선언.
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = -20f;
    public float yVelocity = 0;
    // y축 움직임.

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
        // x,y,z 축 = h,0,v 변수에서 읽어와 vector3로 만듬 해당값을 moveDirection에 넘김

        moveDirection = cameraTransform.TransformDirection(moveDirection);
        // 카메라 위치

        moveDirection *= moveSpeed;
        // 스피드 곱해서 최종 값 설정

        if (characterController.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
                // y 값을 점프스피드로 넘겨서 처리
            }
        }
        yVelocity += (gravity * Time.deltaTime);
        // y 값은 중력값 * Time.deltaTime ( Time.detaTime 적용시키면 업데이트 함수가 게속 반복되면서 실행되는데 업데이트 함수가 종료되고 다시 실행되는 그 사이의 시간이 Time.deltaTime 함수임 )

        moveDirection.y = yVelocity;
        // 계산한 y 값을 moveDirection.y ( y축 움직임 방향 ) 으로 넘겨줌

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
