using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class spawn : MonoBehaviour
{
    public GameObject[] Prefab; // AI 프리팹을 할당할 변수
    private bool spawnStart = true;
    public List<int[]> stageSet = new List<int[]>();

    //스테이지 몬스터 출현 결정 배열
    int count = 0;
    int stageLevel = 0;

    public List<int> stage = new List<int>();

    int[] stage1 = new int[30] { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage2 = new int[30] { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage3 = new int[30] { 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage4 = new int[30] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage5 = new int[30] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

    public Transform spawnPoint; // 생성할 위치
    private int maxSpawnCount = 30; // 생성 수
    public float spawnInterval = 5f; // 생성 간격

    private int spawnCount = 0; // 생성된 수
    private float timer = 0f; // 경과 시간

    private AudioSource spawnAudio;

    private void Start()
    {
        stageSet.Add(stage1);
        stageSet.Add(stage2);
        stageSet.Add(stage3);
        stageSet.Add(stage4);
        stageSet.Add(stage5);
        spawnAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameController.Instance.stageStart)
        {
            
            timer += Time.deltaTime;

            // 일정 간격으로 생성
            if (timer >= spawnInterval && spawnCount < maxSpawnCount && spawnStart)
            {
                Spawn();
                timer = 0f;
            }
        }

        if (!spawnStart && transform.childCount == 0) {
            GameController.Instance.stageState = true;
            GameController.Instance.stageClearText(!spawnStart);
            GameController.Instance.stageStart = false;
            spawnStart = true;
            spawnCount = 0;
            count = 0;
        }
    }

    private void Spawn()
    {
        if (stageSet[stageLevel][count] != 4) { 
        GameObject newChild = Instantiate(Prefab[stageSet[stageLevel][count++]]);
        newChild.transform.parent = spawnPoint.transform;
        }

        // AI 프리팹을 spawnPoint 위치에 생성
        spawnCount++;
        if (spawnCount == 1)
        {
            spawnAudio.Play();
        }

        // 생성된 AI의 수가 maxSpawnCount에 도달하면 스포너 비활성화
        if (spawnCount >= maxSpawnCount)
        {
            spawnStart = false;
            stageLevel++;
            if (stageLevel == 6) {
                stageLevel = 0;
            }
        }
    }
}
