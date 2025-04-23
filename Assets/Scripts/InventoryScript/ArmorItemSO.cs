using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorTypeEnum
{
    helmet,
    chest,
    gloves,
    pants,
    tibial
}

[CreateAssetMenu(fileName = "Armor Item SO", menuName = "New Armor Item SO")]

public class ArmorItemSO : ItemDataSO
{
    [SerializeField] int _value;
    [SerializeField] ArmorTypeEnum _armorType;

    public int Value { get => _value; set => _value = value; }
    public ArmorTypeEnum Consumabletype { get => _armorType; set => _armorType = value; }
}
