using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CounsumableItemTypeEnum
{
    Heal,
    Poison
}

[CreateAssetMenu(fileName = "Consumable Item SO", menuName = "New Consumable Item SO")]

public class ConsumableItemSO : ItemDataSO
{
    [SerializeField] int value;
    [SerializeField] CounsumableItemTypeEnum _consumableType;

    public int Value { get => value; set => this.value = value; }
    public CounsumableItemTypeEnum Type { get => _consumableType; set => _consumableType = value; }
}
