using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 20f;
    public int Damage;

    private int chainMax = 3;
    private int currentChain = 0;
    private List<Transform> passed = new List<Transform>();

    public void Seek(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget() {
        if (target.CompareTag("Enemy"))
        {
            if (GameController.Instance.chain >= GameController.Instance.chainMin)
            {
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamage(Damage);
                    if (currentChain < chainMax)
                    {
                        Seek(enemy.FindClosestEnemy(passed));
                        currentChain++;
                    }
                    else
                    {
                        passed.Clear();
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().GetDamage(Damage);
        }
    }
}

