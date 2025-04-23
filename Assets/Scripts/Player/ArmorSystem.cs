using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    ItemsFactory factory;
    [SerializeField] List<EquipedArmor> equipedArmor = new();
    [SerializeField] ItemDataBaseSO itemsDataBase;


    private void Start()
    {
        factory = gameObject.AddComponent<ItemsFactory>();
        factory.Initialize(itemsDataBase);
    }


    public void EquipArmor(ArmorItemSO armorData)
    {
        EquipedArmor armor = equipedArmor.Find(x => x.ArmorType == armorData.ArmorType);
        factory.CreateItem(armorData.Id, armor.ArmorPivot.position, armor.ArmorPivot);

    }
}

[Serializable]
public class EquipedArmor
{
    [SerializeField] ArmorTypeEnum _armorType;
    [SerializeField] Transform _armorPivot;
    [SerializeField] ArmorItemSO _armorData;
    [SerializeField] GameObject _armorGO;

    public ArmorTypeEnum ArmorType { get => _armorType; set => _armorType = value; }
    public Transform ArmorPivot { get => _armorPivot; set => _armorPivot = value; }
    public ArmorItemSO ArmorData { get => _armorData; set => _armorData = value; }
    public GameObject ArmorGO { get => _armorGO; set => _armorGO = value; }
}