using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameController : MonoBehaviour
{

    public TMP_Text timeText;
    public float time;

    SpriteRenderer render = new SpriteRenderer();
    private int count = 0;
    private int countMax = 12;
    private int level = 0;
    private int checkRight = 0;
    private int gamelevel = 0;
    private int randomFish;
    private bool makeNew = false;
    private int direction;
    private int chance = 3;

    public GameObject delecter;
    public GameObject bar;
    public GameObject barLeftEnd;
    public GameObject barRightEnd;
    public GameObject directionObj;
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject obj;
    public Transform Appear;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        makeFish();
        makeBar();
        makeDirection();
        makeDelecter();
    }
    private void Start()
    {
        count = 0;
    }

    void makeFish()
    {
        if (randomFish == 0)
        {
            fish1 = Instantiate(fish1, Appear.position, Quaternion.identity);
            fish1.transform.position = new Vector3(0, 0, 0);
        }
        else if (randomFish == 1)
        {
            fish2 = Instantiate(fish2, Appear.position, Quaternion.identity);
            fish2.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            fish3 = Instantiate(fish3, Appear.position, Quaternion.identity);
            fish3.transform.position = new Vector3(0, 0, 0);
        }
    }


    void makeBar()
    {
        if (level == 0)
        {
            bar = Instantiate(bar, Appear.position, Quaternion.identity);
            bar.transform.position = new Vector3(0, 4, 0);

            barLeftEnd = Instantiate(barLeftEnd, Appear.position, Quaternion.identity);
            barLeftEnd.transform.position = new Vector3(-5.74f, 4, 0);

            barRightEnd = Instantiate(barRightEnd, Appear.position, Quaternion.identity);
            barRightEnd.transform.position = new Vector3(5.74f, 4, 0);

        }
        else if (level == 1)
        {
            bar = Instantiate(bar, Appear.position, Quaternion.identity);
            bar.transform.position = new Vector3(0, 4, 0);
            bar.transform.localScale = new Vector3(1.2f, 1, 1);

            barLeftEnd = Instantiate(barLeftEnd, Appear.position, Quaternion.identity);
            barLeftEnd.transform.position = new Vector3(-6.78f, 4, 0);

            barRightEnd = Instantiate(barRightEnd, Appear.position, Quaternion.identity);
            barRightEnd.transform.position = new Vector3(6.78f, 4, 0);

        }
        else if(level >= 2)
        {
            bar = Instantiate(bar, Appear.position, Quaternion.identity);
            bar.transform.position = new Vector3(0, 4, 0);
            bar.transform.localScale = new Vector3(1.4f, 1, 1);

            barLeftEnd = Instantiate(barLeftEnd, Appear.position, Quaternion.identity);
            barLeftEnd.transform.position = new Vector3(-7.84f, 4, 0);

            barRightEnd = Instantiate(barRightEnd, Appear.position, Quaternion.identity);
            barRightEnd.transform.position = new Vector3(7.84f, 4, 0);
        }
    }

    void makeDirection() {
        if (level == 0)
        {
            if (direction == 0)
            {
                directionObj = Instantiate(directionObj, Appear.position, Quaternion.identity);
                directionObj.transform.position = new Vector3(-5.74f, 3, 0);

            }
            else if (direction == 1)
            {
                directionObj = Instantiate(directionObj, Appear.position, Quaternion.identity);
                directionObj.transform.Rotate(180, 0, 180);
                directionObj.transform.position = new Vector3(-5.74f, 3, 0);
            }
        }
        else if (level == 1)
        {
            if (direction == 0)
            {
                directionObj = Instantiate(directionObj, Appear.position, Quaternion.identity);
                directionObj.transform.position = new Vector3(-6.78f, 3, 0);
            }
            else if (direction == 1)
            {
                directionObj = Instantiate(directionObj, Appear.position, Quaternion.identity);
                directionObj.transform.Rotate(180, 0, 180);
                directionObj.transform.position = new Vector3(-6.78f, 3, 0);
            }
        }
        else if (level >= 2)
        {
            if (direction == 0)
            {
                directionObj = Instantiate(directionObj, Appear.position, Quaternion.identity);
                directionObj.transform.position = new Vector3(-7.84f, 3, 0);
            }
            else if (direction == 1)
            {
                directionObj = Instantiate(directionObj, Appear.position, Quaternion.identity);
                directionObj.transform.Rotate(180, 0, 180);
                directionObj.transform.position = new Vector3(-7.84f, 3, 0);
            }
        }
    }

    void makeDelecter() {
        delecter =  Instantiate(delecter, Appear.position, Quaternion.identity);
        delecter.transform.position = new Vector3(-9f, 4, 0);
    }

    void Update()
    {
        if (chance == 0) {
            SceneManager.LoadScene("gameOver");
        }

        if (count < countMax) {
            GameObject t_note = Instantiate(obj, Appear.position, Quaternion.identity);
            if (level == 0)
            {
                t_note.transform.position = new Vector3(-5.5f + count, 4, 0);
            }
            else if (level == 1)
            {
                t_note.transform.position = new Vector3(-6.54f + count, 4, 0);
            }
            else if (level >= 2)
            {
                t_note.transform.position = new Vector3(-7.49f + count, 4, 0);
            }
            t_note.transform.SetParent(this.transform);
            count++;
        }

        time += Time.deltaTime;
        timeText.text = time.ToString();

        if (transform.childCount != 0 && direction == 0)
        {
            ButtonSet AM = transform.GetChild(0).gameObject.GetComponent<ButtonSet>();
            checkRight += AM.Check();
        }
        else if (transform.childCount != 0 && direction == 1)
        {
            ButtonSet AM = transform.GetChild(transform.childCount - 1).gameObject.GetComponent<ButtonSet>();
            checkRight += AM.Check();
        }

        if (transform.childCount == 0 && !makeNew)
        {
            checkRight += destroyArrows.instance.returnDestroyCnt();
            destroyArrows.instance.initDestroyCnt();
            if (checkRight % 100 >= 5) //실패가 다섯개 이상이면
            {
                catHandScript.instance.mistake();
                catHandScript.instance.execute();
                checkRight = 0;
                chance--;
            }
            else //실패가 다섯개 미만이면
            {
                scoreSystem.instance.updateScore(time);
                catHandScript.instance.cut();
                catHandScript.instance.execute();
                checkRight = 0;
                gamelevel++;
            }
            makeNew = true;
        }
        else if (transform.childCount == 0 && makeNew)
        {
            time = 0;
            if (gamelevel == 3) {
                level++;
                Destroy(bar);
                Destroy(barLeftEnd);
                Destroy(barRightEnd);

                makeBar();

                if (randomFish == 0)
                {
                    Destroy(fish1);
                }
                else if (randomFish == 1)
                {
                    Destroy(fish2);
                }
                else if (randomFish == 2)
                {
                    Destroy(fish3);
                }
                if (countMax != 16)
                {
                    countMax += 2;
                }
                randomFish = Random.Range(0, 3);
                makeFish();
            }
            direction = Random.Range(0, 2);
            Destroy(directionObj);
            makeDirection();
            count = 0;
            makeNew = false;
        }
    }
}
