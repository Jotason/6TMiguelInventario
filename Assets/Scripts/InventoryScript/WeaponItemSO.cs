using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypeEnum
{
    sword,
    dagger,
    hammer,
    axe,
    lance

}

[CreateAssetMenu(fileName = "Weapom Item SO", menuName = "New Weapom Item SO")]

public class WeaponItemSO : ItemDataSO
{
    [SerializeField] int _damage;
    [SerializeField] WeaponTypeEnum _weaponType;

    public int Damage { get => _damage; set => _damage = value; }
    public WeaponTypeEnum WeaponType { get => _weaponType; set => _weaponType = value; }
}
