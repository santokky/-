using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_item : MonoBehaviour
{
    item_information itemInfo;

    // Start is called before the first frame update
    private void Awake()
    {
        itemInfo = GameManager.instance.transform.GetComponent<item_information>();
    }
}
