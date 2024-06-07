using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSet : MonoBehaviour
{
    private int up = 90;
    private int down = -90;
    private int left = 180;
    private int right = 0;
    int randomRotate; //화살표 방향 로직용 변수

    SpriteRenderer render; //화살표 색깔 변경 변수

    public GameObject sucess; //성공적으로 눌렀을때 터지는 효과
    public GameObject fail; //실패적으로 눌렀을때 터지는 효과

    public Sprite triagle;
    public Sprite square;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rotateArrow();
    }

    void rotateArrow() 
    {
        randomRotate = Random.Range(0, 5);

        if (randomRotate <= 3)
        {
            render.sprite = triagle;
        }
        else {
            render.sprite = square;
        }

        if (randomRotate == 0) //평범한 위방향
        {
            this.transform.Rotate(0, 0, up);
            render.color = new Color(20 / 255f, 249 / 255f, 5 / 255f, 255 / 255f);
        }
        else if (randomRotate == 1) //평범한 아래방향
        {
            this.transform.Rotate(0, 0, down);
            render.color = new Color(0 / 255f, 254 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (randomRotate == 2) //평범한 왼쪽방향
        {
            this.transform.Rotate(0, 0, left);
            render.color = new Color(195 / 255f, 75 / 255f, 152 / 255f, 255 / 255f);
        }
        else if (randomRotate == 3)
        { //평범한 오른쪽방향
            this.transform.Rotate(0, 0, right);
            render.color = new Color(250 / 255f, 56 / 255f, 64 / 255f, 255 / 255f);
        }
        else if (randomRotate == 4) {
            render.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }
    }

    public int Check() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && randomRotate == 0)
        {
            //올바른 키 입력
            Instantiate(sucess, transform.position, transform.rotation);
            Destroy(gameObject);
            return 100;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && randomRotate != 0)
        {
            //잘못된 키 입력
            Instantiate(fail, transform.position, transform.rotation);
            Destroy(gameObject);
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && randomRotate == 1)
        {
            //올바른 키 입력
            Instantiate(sucess, transform.position, transform.rotation);
            Destroy(gameObject);
            return 100;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && randomRotate != 1)
        {
            //잘못된 키 입력
            Instantiate(fail, transform.position, transform.rotation);
            Destroy(gameObject);
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && randomRotate == 2)
        {
            //올바른 키 입력
            Instantiate(sucess, transform.position, transform.rotation);
            Destroy(gameObject);
            return 100;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && randomRotate != 2)
        {
            //잘못된 키 입력
            Instantiate(fail, transform.position, transform.rotation);
            Destroy(gameObject);
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && randomRotate == 3)
        {
            //올바른 키 입력
            Instantiate(sucess, transform.position, transform.rotation);
            Destroy(gameObject);
            return 100;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && randomRotate != 3)
        {
            //잘못된 키 입력
            Instantiate(fail, transform.position, transform.rotation);
            Destroy(gameObject);
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && randomRotate == 4)
        {
            //올바른 키 입력
            Instantiate(sucess, transform.position, transform.rotation);
            Destroy(gameObject);
            return 100;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && randomRotate != 4)
        {
            //잘못된 키 입력
            Instantiate(fail, transform.position, transform.rotation);
            Destroy(gameObject);
            return 1;
        }
        return 0;
    }
}
