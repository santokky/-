using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunker : MonoBehaviour
{
    public int maxHealth = 100; // Finish 오브젝트의 최대 체력
    public int damageAmount = 20; // 각 충돌마다 줄어들 체력 양

    private int currentHealth; // 현재 체력

    private void Start()
    {
        currentHealth = maxHealth; // 시작 시 현재 체력을 최대 체력으로 초기화
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Enemy 오브젝트 삭제

            currentHealth -= damageAmount; // Finish 오브젝트의 체력 감소

            // 체력이 0 이하로 떨어지면 처리할 로직을 여기에 추가
            if (currentHealth <= 0)
            {
                // 체력이 0 이하로 떨어진 경우의 동작 처리
                Debug.Log("Finish destroyed!");
                // 여기에서 Finish 오브젝트를 삭제하거나 다른 동작을 수행할 수 있습니다.
            }
        }
    }
}
