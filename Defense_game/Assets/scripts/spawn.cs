using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class spawn : MonoBehaviour
{
    public GameObject[] Prefab; // AI �������� �Ҵ��� ����
    private bool spawnStart = true;
    public List<int[]> stageSet = new List<int[]>();

    //�������� ���� ���� ���� �迭
    int count = 0;
    int stageLevel = 0;

    public List<int> stage = new List<int>();

    int[] stage1 = new int[30] { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage2 = new int[30] { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage3 = new int[30] { 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage4 = new int[30] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    int[] stage5 = new int[30] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

    public Transform spawnPoint; // ������ ��ġ
    private int maxSpawnCount = 30; // ���� ��
    public float spawnInterval = 5f; // ���� ����

    private int spawnCount = 0; // ������ ��
    private float timer = 0f; // ��� �ð�

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

            // ���� �������� ����
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

        // AI �������� spawnPoint ��ġ�� ����
        spawnCount++;
        if (spawnCount == 1)
        {
            spawnAudio.Play();
        }

        // ������ AI�� ���� maxSpawnCount�� �����ϸ� ������ ��Ȱ��ȭ
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
