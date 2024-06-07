using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    float speed;
    float movingDistance = 24f;
    int randomPattern;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        speed = GameManager.instance.speed;
        movingDistance -= speed * Time.deltaTime; //speed가 음수이므로

        randomPattern = Random.Range(0, prefabs.Length);

        if (movingDistance >= 24f - 1f) {
            GameObject newObj = Instantiate(prefabs[randomPattern], new Vector2(this.transform.position.x, -11.5f), Quaternion.identity);
            newObj.transform.parent = transform;
            movingDistance = 0;
        }
    }
}
