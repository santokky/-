using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTurret : MonoBehaviour
{
    public GameObject[] tile;
    public int cost;
    public GameObject[] towerPrefabs;
    public Vector3 InstantiatedCubePos;
    private float tileSize = 1f; // 타일의 크기를 지정 (예: 1x1 유닛)
    private HashSet<string> occupiedTilePositions = new HashSet<string>(); // 생성된 큐브의 위치를 저장
    private bool selectKey = true;
    private bool buildTower = false;
    public Text goldValue;
    public Text alertMoney;
    public float fadeDuration = 0.6f;
    private int currentMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = int.Parse(goldValue.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectKey)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (GameController.Instance.tileCount1 == 1 && TowerValueCheck(0))
                {
                    tile[0].GetComponent<randomButton>().spriteAlphaReduce();
                    cost = tile[0].GetComponent<randomButton>().returnTowerNum();
                    selectKey = false;
                    buildTower = true;
                    GameController.Instance.tileCount1--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (GameController.Instance.tileCount2 == 1 && TowerValueCheck(1))
                {
                    tile[1].GetComponent<randomButton>().spriteAlphaReduce();
                    cost = tile[1].GetComponent<randomButton>().returnTowerNum();
                    selectKey = false;
                    buildTower = true;
                    GameController.Instance.tileCount2--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (GameController.Instance.tileCount3 == 1 && TowerValueCheck(2))
                {
                    tile[2].GetComponent<randomButton>().spriteAlphaReduce();
                    cost = tile[2].GetComponent<randomButton>().returnTowerNum();
                    selectKey = false;
                    buildTower = true;
                    GameController.Instance.tileCount3--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (GameController.Instance.tileCount4 == 1 && TowerValueCheck(3))
                {
                    tile[3].GetComponent<randomButton>().spriteAlphaReduce();
                    cost = tile[3].GetComponent<randomButton>().returnTowerNum();
                    selectKey = false;
                    buildTower = true;
                    GameController.Instance.tileCount4--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (GameController.Instance.tileCount5 == 1 && TowerValueCheck(4))
                {
                    tile[4].GetComponent<randomButton>().spriteAlphaReduce();
                    cost = tile[4].GetComponent<randomButton>().returnTowerNum();
                    selectKey = false;
                    buildTower = true;
                    GameController.Instance.tileCount5--;
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (buildTower && Physics.Raycast(ray, out hit) && hit.collider.CompareTag("tile"))
            {
                // 레이 캐스팅을 사용하여 Tile 태그가 있는 오브젝트를 검사
                float tileX = Mathf.RoundToInt(hit.point.x / tileSize) * tileSize;
                float tileZ = Mathf.RoundToInt(hit.point.z / tileSize) * tileSize;

                InstantiatedCubePos = new Vector3(tileX, towerPrefabs[cost].transform.localScale.y, tileZ);

                // 이미 생성된 위치가 아닌 경우만 큐브 생성
                string tilePosKey = $"{tileX},{tileZ}";
                if (!occupiedTilePositions.Contains(tilePosKey))
                {
                    GameObject Obj = Instantiate(towerPrefabs[cost], InstantiatedCubePos, Quaternion.identity) as GameObject;
                    occupiedTilePositions.Add(tilePosKey); // 생성된 위치를 저장한다
                }

                buildTower = false;
                selectKey = true;
            }
        }
    }

    public bool TowerValueCheck(int num)
    {
        currentMoney = int.Parse(goldValue.text);
        int towerValue = tile[num].GetComponent<randomButton>().returnTowerValue();
        if (currentMoney < towerValue)
        {
            StartCoroutine(FadeText());
            return false;
        }
        else
        {
            if (towerValue == 5)
            {
                GameController.Instance.Ice += 1;
            }
            else if (towerValue == 10)
            {
                GameController.Instance.Ice += 1;
                GameController.Instance.fire += 1;
            }
            else if (towerValue == 15)
            {
                GameController.Instance.Ice += 1;
                GameController.Instance.fire += 2;
                GameController.Instance.chain += 1;
            }
            else if (towerValue == 20)
            {
                GameController.Instance.Ice += 2;
                GameController.Instance.fire += 2;
                GameController.Instance.chain += 2;
            }
            else if (towerValue == 25)
            {
                GameController.Instance.Ice += 3;
                GameController.Instance.fire += 3;
                GameController.Instance.chain += 3;
            }
            currentMoney -= towerValue;
            goldValue.text = "" + currentMoney;
            return true;
        }
    }

    private IEnumerator FadeText()
    {
        alertMoney.color = new Color(alertMoney.color.r, alertMoney.color.g, alertMoney.color.b, 0.1f);

        yield return new WaitForSeconds(0.1f);

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // 1부터 0까지 알파 값 보간
            float alpha = Mathf.Lerp(1f, 0f, normalizedTime);
            alertMoney.color = new Color(alertMoney.color.r, alertMoney.color.g, alertMoney.color.b, alpha);

            yield return null;
        }
    }
}
