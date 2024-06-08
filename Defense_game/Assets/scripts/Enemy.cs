using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float CurrentSpeed;

    private Transform target;
    private int wavepointIndex = 0;
    private Bullet bulletDamge;
    RectTransform rectTransform;
    private Animator anim;
    private bool isDead = false;
    private int deadCount = 1;

    public int monsterValue = 0;

    [Header("enemyInformation")]
    public string MonsterTag;
    string[] aniName = { "Cactus_Die", "Mushroom_DieSmile" };
    public Image hpValue;
    private float HP = 3;
    public float armor = 1;
    public float iceArmor = 1;
    public float fireArmor = 1;
    public int bonusMoney = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rectTransform = hpValue.GetComponent<RectTransform>();
        target = Waypoints.points[0];
        CurrentSpeed = speed;
    }

    private void Update()
    {

        if (isDead) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            Quaternion newRotation = target.rotation;
            transform.rotation = newRotation;
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject);
            GameController.Instance.changeHeart();
        }
        wavepointIndex++;
        if (wavepointIndex == Waypoints.points.Length) {
            return;
        }
        target = Waypoints.points[wavepointIndex];
    }

    public void GetDamage(int Damage) {
        float realDamage = Damage / (33f * armor);
        HP -= realDamage;
        rectTransform.sizeDelta = new Vector2(HP, rectTransform.sizeDelta.y);

        if (GameController.Instance.Ice >= GameController.Instance.IceMin)
        {
            StartCoroutine(IceAttack());
        }

        if (GameController.Instance.fire >= GameController.Instance.fireMin) {
            float fireDamage = Damage / (99f * fireArmor);
            int tickNum = 10;
            StartCoroutine(FireAttack(fireDamage, tickNum));
        }

        if (HP <= 0)
        {
            if (deadCount >= 1)
            {
                isDead = true;
                Die();
                deadCount--;
            }
        }
    }

    //죽었을때
    private void Die()
    {
            GameController.Instance.changeMoney(monsterValue);
            gameObject.tag = "Untagged";
            anim.SetTrigger("Die");

            if (MonsterTag == "Cactus")
                anim.Play(aniName[0]);
            else
                anim.Play(aniName[1]);

            StartCoroutine(DestroyAfterDelay(1f));
    }

    //얼음공격
    private IEnumerator IceAttack() {
        if (speed > 0.75f) {
            if (iceArmor < 2)
            {
                speed = speed * 0.9f;
                if (speed < 0.75f)
                {
                    speed = 0.75f;
                }
                yield return new WaitForSeconds(3f);
                speed = CurrentSpeed;
            }
        }
    }

    //불공격
    private IEnumerator FireAttack(float fireDamage, int tickNum)
    {
        for (int i = 0; i < tickNum; i++)
        {
            HP -= fireDamage / tickNum;
            rectTransform.sizeDelta = new Vector2(HP, rectTransform.sizeDelta.y);
            if (HP > 0)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else if (HP <= 0)
            {
                if (deadCount >= 1)
                {
                    isDead = true;
                    Die();
                    deadCount--;
                }
            }
        }
    }

    //연쇄공격
    public Transform FindClosestEnemy(List<Transform> passed)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
        List<Transform> enemies = new List<Transform>();

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy") && collider.transform != this.transform)
            {
                enemies.Add(collider.transform);
            }
        }

        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform enemy in enemies)
        {
            if (!passed.Contains(enemy))
            {
                float distance = Vector3.Distance(transform.position, enemy.position);
                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }
        }

        if (closestDistance != null)
        {
            passed.Add(closestEnemy);
        }

        return closestEnemy;
    }


    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
