using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime = 2;    // 2���� ���ӿ�����Ʈ ����
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
