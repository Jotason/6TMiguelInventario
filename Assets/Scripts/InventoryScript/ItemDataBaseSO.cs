using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Database SO", menuName = "New Items Database SO")]
public class ItemDataBaseSO : ScriptableObject
{
    [SerializeField] List<ItemDataSO> _items = new();


    public ItemDataSO SearchById(int id) { 
        return _items.FirstOrDefault(x => x.Id == id);
    }
}
