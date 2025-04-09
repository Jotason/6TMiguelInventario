using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeEnum
{ 
    Consumable,
    Armor,
    Weapon
}

public class ItemDataSO : ScriptableObject
{

    [Header("Item data")]
    [SerializeField] int _id;

    [SerializeField] string _itemName;

    [SerializeField] Sprite _icon;

    [SerializeField] GameObject _prefab;

    [SerializeField] ItemTypeEnum _itemtype;

    public int Id { get => _id; set => _id = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }
    public ItemTypeEnum Itemtype { get => _itemtype; set => _itemtype = value; }
}
