using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType { maxHP, speed, power, armor, hp, exp, magnet }

    [Header("# Main Info")]
    public ItemType itemtype;
    public int itemId;
    public string itemName;
    public string itemDesc;
    public Sprite itemIcon;

    [Header("# Item ability Data")]
    public float baseAbility;
    public float bonusScore;
}